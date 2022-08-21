using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int number = 1; number <= range; number++)
            {
                int tempNumber = number;
                int sumOfDigits = 0;
                while (number > 0)
                {
                    sumOfDigits += number % 10;
                    number = number / 10;
                }
                bool isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", tempNumber, isSpecial);
                number = tempNumber;
            }
        }
    }
}
