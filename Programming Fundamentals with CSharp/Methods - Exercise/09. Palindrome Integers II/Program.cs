using System;

namespace _09._Palindrome_Integers_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(IsPalindrom(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        static bool IsPalindrom(string line)
        {
            int j = line.Length - 1;
            for (int i = 0; i < line.Length/2; i++)
            {
                if (line[i] != line[j-i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
