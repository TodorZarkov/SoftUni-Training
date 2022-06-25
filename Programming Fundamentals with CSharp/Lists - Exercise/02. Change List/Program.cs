using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] command = line.Split(' ').ToArray();
                if (command[0] == "Delete")
                {
                    while (numbers.Remove(int.Parse(command[1]))) ;   
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                line = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', numbers));

        }
    }
}
