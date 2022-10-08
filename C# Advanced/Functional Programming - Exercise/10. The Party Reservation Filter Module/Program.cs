using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string line = Console.ReadLine();
            while (line != "Print")
            {
                string[] commands = line.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string toDo = commands[0];
                string condition = commands[1];
                string arg = commands[2];

                if (toDo == "Add filter")
                {
                    filters.Add(condition + arg, Filter(condition, arg));
                }
                else if (toDo == "Remove filter")
                {
                    filters.Remove(condition + arg);
                }

                line = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                names.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", names));

        }

        public static Predicate<string> Filter(string condition, string arg)
        {
            switch (condition)
            {
                case "Starts with":
                    return name => name.StartsWith(arg);
                case "Ends with":
                    return name => name.EndsWith(arg);
                case "Length":
                    return name => name.Length == int.Parse(arg);
                case "Contains":
                    return name => name.Contains(arg);
            }
            return null;
        }
    }
}
