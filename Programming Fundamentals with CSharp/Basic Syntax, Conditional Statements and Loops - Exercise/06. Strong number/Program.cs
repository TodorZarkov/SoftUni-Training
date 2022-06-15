using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            ulong originalNumber = number;

            ulong digit = number % 10;
            number = number / 10;
            ulong factSum = 0;
            while (digit != 0)
            {
                ulong fact = 1;
                for (uint i = 1; i <= digit; i++)
                {
                    fact *= i;
                }
                factSum += fact;
                digit = number % 10;
                number /= 10;
            }
            if (factSum == originalNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
