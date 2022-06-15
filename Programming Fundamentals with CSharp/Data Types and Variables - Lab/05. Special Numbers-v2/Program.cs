using System;

namespace _05._Special_Numbers_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int  range = int.Parse(Console.ReadLine());
            for (int number = 1; number <= range; number++)
            {
                string digits =number.ToString();
                int sum = 0;
                foreach (var digit in digits)
                {
                    sum += int.Parse(digit.ToString());
                }
                Console.WriteLine($"{number} -> {sum == 5 || sum == 7 || sum == 11}");
            }

        }
    }
}
