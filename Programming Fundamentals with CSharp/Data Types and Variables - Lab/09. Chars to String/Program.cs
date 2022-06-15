using System;

namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                word = word + symbol;
            }
            Console.WriteLine(word); 
        }
    }
}
