using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = str => int.Parse(str);
            int smallest = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(parser).Min();
            Console.WriteLine(smallest);

        }
    }
}
