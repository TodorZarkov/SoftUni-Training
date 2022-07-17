using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').Select(w => w.ToLower()).ToList();
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!frequency.ContainsKey(word))
                {
                    frequency[word] = 0;
                }
                frequency[word]++;
            }
            foreach (var kvp in frequency.Where(k => k.Value % 2 != 0))
            {
                Console.Write($"{kvp.Key} ");
            }
            
        }
    }
}
