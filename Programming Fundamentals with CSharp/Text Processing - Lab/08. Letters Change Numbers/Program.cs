using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Regex rx = new Regex(@"\s+");
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            foreach (string group in text)
            {
                result += Formula(ParseBefore(group[0]), ParseNumberBetween(group), ParseAfter(group[group.Length - 1]));
            }
            Console.WriteLine($"{result:f2}");
        }

        static int ParseNumberBetween(string numberBetweenTwoLetters)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < numberBetweenTwoLetters.Length - 1; i++)
            {
                sb.Append(numberBetweenTwoLetters[i]);
            }
            return int.Parse(sb.ToString());
        }

        static double ParseBefore(char letter)
        {
            if (char.IsUpper(letter))
            {
                return 1.0 / ((int)letter - 64);
            }
            else //(char.IsLower(letter))
            {
                return (double)((int)letter - 96);
            }
        }

        static int ParseAfter(char letter)
        {
            if (char.IsUpper(letter))
            {
                return -1*((int)letter - 64);
            }
            else //(char.IsLower(letter))
            {
                return (int)letter - 96;
            }
        }

        static double Formula(double before, int number, int after)
        {
            return before * number + after;
        }
    }
}
