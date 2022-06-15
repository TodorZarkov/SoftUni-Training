using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double grade = 0;
            double sum = 0;
            bool failed = false;

            while (counter <= 12)
            {
                grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    if (failed)
                    {
                        Console.WriteLine($"{name} has been excluded at {counter} grade");
                        return;
                    }
                    else
                    {
                        failed = true;
                        continue;
                    }
                }
                sum += grade;
                counter++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {sum/12:f2}");
        }
    }
}
