using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] commands = line.Split(" : ");
                string courseName = commands[0];
                string registeredStudent = commands[1];
                if (!courses.ContainsKey(courseName))
                {
                    List<string> students = new List<string>();
                    students.Add(registeredStudent);
                    courses[courseName] = students;

                }
                else
                    courses[courseName].Add(registeredStudent);
                line = Console.ReadLine();
            }
            // courses.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}{Environment.NewLine}{string.Join($"{Environment.NewLine}-- ", kvp.Value)}"));
            //              Algorithms: 2
            //              -- Jay Moore
            //              -- Bob Jackson
            //              Programming Basics: 1
            //              -- Martin Taylor
            //              Python Fundamentals: 3
            //              -- John Anderson
            //              -- Andrew Robinson
            //              -- Clark Lewis
            foreach (var kvp in courses)
            {
                System.Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (string name in kvp.Value)
                {
                    System.Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
