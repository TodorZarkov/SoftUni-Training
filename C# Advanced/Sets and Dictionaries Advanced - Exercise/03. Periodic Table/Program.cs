using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < countLines; i++)
            {
                Console.ReadLine().Split().ToList().ForEach(c=>elements.Add(c));
            }
            List<string> sortedElements = elements.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(' ',sortedElements));
        }
    }
}
