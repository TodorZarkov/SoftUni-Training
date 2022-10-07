using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] arr = Enumerable.Range(range[0], range[1] - range[0] + 1).ToArray();
            Predicate<int> getEven = num => num % 2 == 0 ? true : false;
            Predicate<int> getOdd = num => num % 2 == 0 ? false : true;
            var toGet = Console.ReadLine() == "even" ? getEven : getOdd;
            Console.WriteLine(string.Join(' ', arr.Where(x => toGet(x)).ToArray()));
        }
    }
}
