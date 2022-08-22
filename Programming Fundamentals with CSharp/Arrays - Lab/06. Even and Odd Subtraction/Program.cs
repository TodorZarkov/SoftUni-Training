using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int even = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 == 0).Sum();
            int odd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 != 0).Sum();
            Console.WriteLine(even - odd);
        }
    }
}
