using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            for (int i = 0; i < dims[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < dims[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            string result = "";
            foreach (int key in firstSet)
            {
                if (secondSet.Contains(key))
                {
                    result += $"{key} ";
                }
            }
            Console.WriteLine(result.Trim());
        }
    }
}
