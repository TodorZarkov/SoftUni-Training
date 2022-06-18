using System;

namespace _02._FromL_tToR_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            char separator = ' ';
            for (int i = 0; i < lines; i++)
            {
                int sumOfDigits = 0;
                string input = Console.ReadLine();
                int separatorIndex = 0;
                string numberString = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == separator)
                    {
                        separatorIndex = j;
                        break;
                    }
                    numberString += input[j];
                }
                int firstNumber = int.Parse(numberString);

                numberString = string.Empty;
                for (int k = separatorIndex + 1; k < input.Length; k++)
                {
                    numberString += input[k];
                }
                int secondNumber = int.Parse(numberString);

                if (firstNumber >= secondNumber)
                {
                    firstNumber = Math.Abs(firstNumber);
                    int digit = firstNumber % 10;
                    while (firstNumber != 0)
                    {
                        firstNumber = firstNumber / 10;
                        sumOfDigits += digit;
                        digit = firstNumber % 10;
                    }
                }
                else
                {
                    firstNumber = secondNumber;
                    firstNumber = Math.Abs(firstNumber);
                    int digit = firstNumber % 10;
                    while (firstNumber != 0)
                    {

                        firstNumber = firstNumber / 10;
                        sumOfDigits += digit;
                        digit = firstNumber % 10;
                    }
                }
                Console.WriteLine(sumOfDigits);
            }
        }
    }
}
