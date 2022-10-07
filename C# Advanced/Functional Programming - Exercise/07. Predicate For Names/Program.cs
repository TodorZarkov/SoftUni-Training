using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> filterLen = (name, len) => name.Length <= len;
            int len = int.Parse(Console.ReadLine());
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(name => filterLen(name, len)).ToList().ForEach(name => Console.WriteLine(name));
        }
    }
}
