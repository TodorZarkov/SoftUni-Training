using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputWord = Console.ReadLine();
            while (inputWord != "end")
            {
                char[] outputWord = inputWord.ToCharArray();
                Array.Reverse(outputWord);
                Console.Write($"{inputWord} = ");
                Console.WriteLine(outputWord);


                inputWord = Console.ReadLine();
            }
        }
    }
}
