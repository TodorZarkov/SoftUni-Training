using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                names.Add(Console.ReadLine());
            }

            names.ToList().ForEach(name => Console.WriteLine(name));
        }
    }
}
