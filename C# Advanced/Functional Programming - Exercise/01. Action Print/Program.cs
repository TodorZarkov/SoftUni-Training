using System;
using System.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = line => Console.WriteLine(line);
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
        }
    }
}
