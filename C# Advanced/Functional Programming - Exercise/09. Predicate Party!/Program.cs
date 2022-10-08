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
            string line = Console.ReadLine();
            while (line != "Party!")
            {
                string[] commands = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string toDo = commands[0];
                string condition = commands[1];
                string arg = commands[2];

                if (toDo == "Remove")
                {
                    names.RemoveAll(Filter(condition, arg));
                }
                else if (toDo == "Double")
                {
                    names.AddRange(names.FindAll(Filter(condition, arg)));
                }

                line = Console.ReadLine();
            }
            if (names.Count != 0)
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        static Predicate<string> Filter(string condition, string arg)
        {
            switch (condition)
            {
                case "StartsWith":
                    return name => name.StartsWith(arg);
                case "EndsWith":
                    return name => name.EndsWith(arg);
                case "Length":
                    return name => name.Length == int.Parse(arg);
            }
            return null;
        }
    }
}
