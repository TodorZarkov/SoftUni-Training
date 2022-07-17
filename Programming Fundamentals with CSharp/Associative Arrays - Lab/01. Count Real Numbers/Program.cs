using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToList();
            SortedDictionary<int, int> frequency = new SortedDictionary<int, int>();
            foreach (int num in nums)
            {
                if (!frequency.ContainsKey(num))
                {
                    frequency[num] = 0;
                }
                frequency[num]++;
            }

            foreach (var kvp in frequency)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
