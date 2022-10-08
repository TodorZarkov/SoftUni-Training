using System;
using System.Linq;

namespace _07._Predicate_For_Names_VER2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Action<string[], Predicate<string>> printNames = (names, match) =>
            {
                foreach (string name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            printNames(names, name => name.Length <= length);
        }
    }
}
