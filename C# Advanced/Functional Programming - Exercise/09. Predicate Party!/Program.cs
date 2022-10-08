using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Party!")
            {


                command = Console.ReadLine();
            }
        }
    }
}
