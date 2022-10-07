using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Func<int, int,bool> filter = (number,divider) => number%divider!=0;

            int[] result = numbers.Where(n => filter(n, divider)).ToArray();
            int[] arr = new int[result.Length];
            int[] revResult = result.Reverse().ToArray();
            Console.WriteLine(String.Join(' ',revResult));

        }
    }
}
