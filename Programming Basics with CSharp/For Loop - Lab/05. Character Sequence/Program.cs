using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string letter = Console.ReadLine();
            int  len = letter.Length;

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(letter[i]);
            }
        }
    }
}
