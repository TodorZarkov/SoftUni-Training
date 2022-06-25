using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(' ').ToArray();
                if (line[2] == "going!")
                {
                    if (!names.Contains(line[0])) 
                        names.Add(line[0]);
                    else 
                        Console.WriteLine($"{line[0]} is already in the list!");
                }
                else if (line[2] == "not")
                {
                    if (!names.Remove(line[0])) 
                        Console.WriteLine($"{line[0]} is not in the list!");
                }
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
