using System;

namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A number is special when its sum of digits is 5, 7 or 11.
            //Write a program to read an integer n and for all numbers in the range 1…n to print the number and if it is special or not (True / False).
            int range = int.Parse(Console.ReadLine());
            for (int number = 1; number <= range; number++)
            {
                bool isSpecial = false;
                int digitSum = 0;
                int currentNumber = number;
                do
                {
                    byte digit = (byte)(currentNumber % 10);
                    currentNumber /= 10;
                    digitSum += digit;
                } while (currentNumber != 0);
                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{ number} -> { isSpecial}");
            }
        }
    }
}
