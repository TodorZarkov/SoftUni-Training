﻿namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;
    using UniversityCompetition.Models.Contracts;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private ICollection<int> coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;

            coveredExams = new LinkedList<int>();
        }

        public int Id { get; private set; }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => (IReadOnlyCollection<int>)coveredExams;

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
