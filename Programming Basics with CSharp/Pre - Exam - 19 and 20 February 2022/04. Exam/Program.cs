using System;

namespace _04._Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            double grade = 0;
            double top = 0;
            double second = 0;
            double third = 0;
            double failed = 0;
            double avarage = 0;

            for (int i = 1; i <= numStudents; i++)
            {
                grade = double.Parse(Console.ReadLine());
                avarage += grade;
                if (grade >= 5)
                {
                    top++;
                }
                else if (grade >=4 && grade <= 4.99)
                {
                    second++;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    third++;
                }
                else if (grade < 3)
                {
                    failed++;
                }
            }
            Console.WriteLine($"Top students: {top/numStudents*100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {second/numStudents*100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {third/numStudents*100:f2}%");
            Console.WriteLine($"Fail: {failed/numStudents*100:f2}%");
            Console.WriteLine($"Average: {avarage/numStudents:f2}");
        }
    }
}
