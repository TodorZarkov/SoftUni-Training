using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordsSynonyms = new Dictionary<string, List<string>>();
            int numberOfPairs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPairs; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();
                if (!wordsSynonyms.ContainsKey(word))
                {
                    wordsSynonyms[word] = new List<string> { synonim };
                }
                else
                {
                    wordsSynonyms[word].Add(synonim);
                }
            }

            foreach (var kvp in wordsSynonyms)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
