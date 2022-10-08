using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> match = (name, num) =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += (int)name[i];
                }
                if (sum >= num)
                {
                    return true;
                }

                return false;
            };

            Func< Func<string, int, bool>, List<string>, string> get = (match, names) =>
            {
                return names.Find(name => match(name, number));
            };

            Console.WriteLine(get(match,names)); 
        }
    }
}
