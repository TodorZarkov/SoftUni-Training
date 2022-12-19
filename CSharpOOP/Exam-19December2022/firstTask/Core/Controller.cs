namespace UniversityCompetition.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UniversityCompetition.Core.Contracts;
    using UniversityCompetition.Models;
    using UniversityCompetition.Models.Contracts;
    using UniversityCompetition.Repositories;
    using UniversityCompetition.Repositories.Contracts;
    using UniversityCompetition.Utilities.Factories;

    public class Controller : IController
    {
        IRepository<ISubject> subjects;
        IRepository<IStudent> students;
        IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            int subjectId = subjects.Models.Count + 1;
            object item = Factory.Produce(subjectType, new object[] { subjectId, subjectName });
            if (item == null)
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return $"{subjectName} is already added in the repository.";
            }

            ISubject subject = (ISubject)item;
            subjects.AddModel(subject);

            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return $"{universityName} is already added in the repository.";
            }


            ICollection<int> requiredById = requiredSubjects.Select(rs => subjects.FindByName(rs).Id).ToList();

            int universityId = universities.Models.Count + 1;

            IUniversity university = new University(universityId, universityName, category, capacity, requiredById);

            universities.AddModel(university);

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            int studentId = students.Models.Count + 1;
            IStudent student = new Student(studentId, firstName, lastName);
            students.AddModel(student);

            return $"Student {firstName} {lastName} is added to the StudentRepository!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return "Invalid student ID!";
            }

            if (subjects.FindById(subjectId) == null)
            {
                return "Invalid subject ID!";
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            if (student.CoveredExams.Contains(subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);

            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }


        public string ApplyToUniversity(string studentName, string universityName)
        {
            //string[] names = studentName.Split(" ");
            if (students.FindByName(studentName) == null)
            {
                return $"{studentName} is not registered in the application!";
            }

            if (universities.FindByName(universityName) == null)
            {
                return $"{universityName} is not registered in the application!";
            }

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            bool isCoveredAll = true;
            if (university.RequiredSubjects.Count == student.CoveredExams.Count)
            {
                foreach (int subjectId in university.RequiredSubjects)
                {
                    if (!student.CoveredExams.Contains(subjectId))
                    {
                        isCoveredAll = false;
                        break;
                    }
                }

            }
            else
            {
                isCoveredAll = false;
            }

            if (!isCoveredAll)
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return $"{studentName} has already joined {universityName}.";
            }

            student.JoinUniversity(university);
            return $"{studentName} joined {universityName} university!";
        }


        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            int studentsCount = students.Models.
                Sum(s => (s.University != null) && (s.University.Id == universityId) ? 1 : 0);
            int capacityLeft = university.Capacity - studentsCount;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {capacityLeft}");

            return sb.ToString().TrimEnd();
        }
    }
}
