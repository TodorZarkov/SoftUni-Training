using System;

namespace _02._FromL_tToR_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            char separator = ' ';
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                int separatorIndex = input.IndexOf(separator);
                long firstNumber = long.Parse(input.Substring(0,separatorIndex));
                long secondNumber = long.Parse(input.Substring(separatorIndex+1,input.Length-separatorIndex-1));

                int sumOfDigits = 0;
                if (firstNumber >= secondNumber)
                {
                    firstNumber = Math.Abs(firstNumber);
                    int digit = (byte)(firstNumber % 10);
                    while (firstNumber != 0)
                    {
                        firstNumber = firstNumber / 10;
                        sumOfDigits += digit;
                        digit = (byte)(firstNumber % 10);
                    }
                }
                else
                {
                    firstNumber = secondNumber;
                    firstNumber = Math.Abs(firstNumber);
                    int digit = (byte)(firstNumber % 10);
                    while (firstNumber != 0)
                    {

                        firstNumber = firstNumber / 10;
                        sumOfDigits += digit;
                        digit = (byte)(firstNumber % 10);
                    }
                }
                Console.WriteLine(sumOfDigits);
            }
        }
    }
}
