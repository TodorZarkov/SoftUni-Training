using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._List_Of_Predicates_VER2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] numbers = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToArray();
            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            foreach (int p in dividers)
            {
                Predicate<int> predicate = n => n % p == 0;
                predicates.Add(predicate);
            }

            StringBuilder result = new StringBuilder();
            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (var match in predicates)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    result.Append(number);
                    result.Append(' ');
                }
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
