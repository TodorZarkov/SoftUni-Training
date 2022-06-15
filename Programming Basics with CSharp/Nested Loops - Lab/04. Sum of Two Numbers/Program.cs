using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = begin; i <= end; i++)
            {
                for (int j = begin; j <= end; j++)
                {
                    count++;
                    if (i + j == number)
                    {
                        Console.WriteLine($"Combination N:{count} ({i} + {j} = {number})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{count} combinations - neither equals {number}");
        }
    }
}
