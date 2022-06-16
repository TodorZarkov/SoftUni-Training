using System;

namespace _06._TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = 97; //gryph 'a'
            int firstN = int.Parse(Console.ReadLine());
            int length = index + firstN; //26;//to gryph 'z'
            for (int i = index; i < length; i++)
            {
                for (int j = index; j < length; j++)
                {
                    for (int k = index; k < length; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
