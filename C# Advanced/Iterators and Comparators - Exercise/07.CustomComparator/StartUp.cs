using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _07.CustomComparator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ComparatorEvenOdds compar = new ComparatorEvenOdds();
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort<int>(arr, compar);
            Console.WriteLine(String.Join(' ',arr));
        }
    }

    class ComparatorEvenOdds : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            return x - y;
        }
    }
}
