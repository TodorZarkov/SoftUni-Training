using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double avarageGrade = 0;
            int presentationNum = 0;

            while (input != "Finish")
            {
                double grade = 0;
                for (int i = 1; i <= n; i++)
                {
                    grade += double.Parse(Console.ReadLine());
                }
                grade /= n;
                avarageGrade += grade;
                Console.WriteLine($"{input} - {grade:f2}.");

                presentationNum++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {avarageGrade/presentationNum:f2}.");

        }
    }
}
