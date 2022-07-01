using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();
        List<Student> students = new List<Student>();
        while (line != "end")
        {
            string[] stInfo = line.Split(' ').ToArray();
            Student student = new Student
            {
                FirstName = stInfo[0],
                LastName = stInfo[1],
                Age = int.Parse(stInfo[2]),
                HomeTown = stInfo[3]
            };
            students.Add(student);
            line = Console.ReadLine();
        }
        string town = Console.ReadLine();
        List<Student> filtStudents = students.Where(s => s.HomeTown == town).ToList();
        foreach (Student student in filtStudents)
        {
            System.Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
        }

    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }
}
