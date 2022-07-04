using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                Student student = new Student(line[0], line[1], double.Parse(line[2]));
                students.Add(student);
            }
            List<Student> orderedStudents = students.OrderByDescending(student => student.Grade).ToList();
            orderedStudents.ForEach(student => Console.WriteLine(student.ToString()));
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:F2}";
        }
    }
}
