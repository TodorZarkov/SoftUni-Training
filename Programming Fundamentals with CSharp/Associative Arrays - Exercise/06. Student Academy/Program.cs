using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            const double gradeThreshold = 4.50;
            int pairOfRows = int.Parse(Console.ReadLine());
            for (int i = 0; i < pairOfRows; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades[student] = new List<double> { grade };
                }
                else
                {
                    studentsGrades[student].Add(grade);
                }
            }
            foreach (var kvp in studentsGrades.Where(sg => sg.Value.Average() >= gradeThreshold))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
