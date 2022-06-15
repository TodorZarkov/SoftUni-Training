using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 0;
            int sumA = 0;
            int sumB = 0;

            for (int i = 0; i < n; i++)
            {
                a = int.Parse(Console.ReadLine());
                sumA += a;
            }
            for (int i = 0; i < n; i++)
            {
                b = int.Parse(Console.ReadLine());
                sumB += b;
            }
            int diff = sumA - sumB;
            if (diff==0)
            {
                Console.WriteLine($"Yes, sum = {sumA}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(diff)}");
            }
        }
    }
}
