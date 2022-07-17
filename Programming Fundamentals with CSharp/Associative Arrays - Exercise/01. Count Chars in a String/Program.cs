using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> symbols = Console.ReadLine().Where(w => w != ' ').ToList();
            Dictionary<char, int> occurences = new Dictionary<char, int>();
            foreach (char symbol in symbols)
            {
                if (!occurences.ContainsKey(symbol))
                {
                    occurences[symbol] = 0;
                }
                occurences[symbol]++;
            }

            occurences.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key} -> {kvp.Value}"));
        }
    }
}
