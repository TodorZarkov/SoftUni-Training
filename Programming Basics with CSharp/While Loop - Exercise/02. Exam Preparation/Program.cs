using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitOfPoorGrades = int.Parse(Console.ReadLine());
            string problemName = "";
            int numberOfPoorGrades = 0;
            int grade = 0;
            int averageGrade = 0;
            int problems = 0;


            while (numberOfPoorGrades < limitOfPoorGrades)
            {

                string lastProblem = problemName;
                problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    Console.WriteLine($"Average score: {1.0*averageGrade/problems:f2}");
                    Console.WriteLine($"Number of problems: {problems}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }
                grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    numberOfPoorGrades++;
                }

                averageGrade += grade;
                problems++;
            }
            if (numberOfPoorGrades == limitOfPoorGrades)
            {
                Console.WriteLine($"You need a break, {limitOfPoorGrades} poor grades.");
            }

            
        }
    }
}
