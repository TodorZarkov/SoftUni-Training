using System;

namespace _07._Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string symbol1 = Console.ReadLine();
            string symbol2 = Console.ReadLine();
            string symbol3 = Console.ReadLine();
            Console.WriteLine($"{symbol1}{symbol3}{symbol2}");
        }
    }
}
