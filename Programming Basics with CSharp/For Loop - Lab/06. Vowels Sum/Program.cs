using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string vowels = "aeiou";
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < text.Length; k++)
                {
                    if (text[k] == vowels[i])
                    {
                        sum += i + 1;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
