using System;

namespace _02.Eng.NameOfTheLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(EnglishNameOfTheLastDigit(input));
        }
        static string EnglishNameOfTheLastDigit (int number)
        {
            number %= 10;
            string strNumber = string.Empty;
            switch (number)
            {
                case 0:
                    strNumber = "zero";
                    break;
                    case 1:
                    strNumber = "one";
                    break;
                case 2:
                    strNumber = "two";
                    break;
                case 3:
                    strNumber = "three";
                    break;
                case 4:
                    strNumber = "four";
                    break;
                case 5:
                    strNumber = "five";
                    break;
                case 6:
                    strNumber = "six";
                    break;
                case 7:
                    strNumber = "seven";
                    break;
                case 8:
                    strNumber = "eight";
                    break;
                case 9:
                    strNumber = "nine";
                    break;
            }
            return strNumber;
            
        }

    }
}
