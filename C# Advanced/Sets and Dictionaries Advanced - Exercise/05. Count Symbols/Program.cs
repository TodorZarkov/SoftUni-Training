using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            foreach (char symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }
                symbols[symbol]++;
            }

            symbols.OrderBy(x => x.Key).ToList().
                ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s"));
            
        }
    }
}
