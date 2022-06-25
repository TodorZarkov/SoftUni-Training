using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] command = line.Split(' ');
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index < numbers.Count)
                        numbers.Insert(index, int.Parse(command[1]));
                    else
                        Console.WriteLine("Invalid index");
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < numbers.Count)
                        numbers.RemoveAt(index);
                    else
                        Console.WriteLine("Invalid index");

                }
                else if (command[0] == "Shift" && command[1] == "left")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }
                }
                else if (command[0] == "Shift" && command[1] == "right")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        numbers.Insert(0, numbers.Last());
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
