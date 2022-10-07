using System;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int[], bool> filters = (number, dividers) =>
            {
                bool result = true;
                foreach (var divider in dividers)
                {
                    if (number % divider != 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            };

            int[] range = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToArray();
            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] filtered = range.Where(number => filters(number, dividers)).ToArray();
            Console.WriteLine(String.Join(' ',filtered));
            
        }
    }
}
