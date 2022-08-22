using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            foreach(double number in numbers)
            {
                Console.WriteLine($"{number} => {(int)Math.Round(number,MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
