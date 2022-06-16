using System;

namespace _05._PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startSymbol = int.Parse(Console.ReadLine());
            int endSymbol = int.Parse(Console.ReadLine());

            for (int i = startSymbol; i <= endSymbol; i++)
            {
                char symbol = (char)i;
                Console.Write($"{symbol} ");
            }
        }
    }
}
