using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int capacity = int.Parse(Console.ReadLine());

        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] split = input.Split(' ').ToArray();
            if (split[0] == "Add")
            {
                wagons.Add(int.Parse(split[1]));
            }
            else
            {
                int incPassengers = int.Parse(split[0]);
                for (int i = 0; i < wagons.Count; i++)
                {

                    if (wagons[i] + incPassengers <= capacity)
                    {
                        wagons[i] += incPassengers;
                        incPassengers = 0;
                    }
                    // else if (capacity - wagons[i] != 0)
                    // {
                    //     wagons[i] = capacity;
                    //     incPassengers -= (capacity - wagons[i]);
                    // }

                    // if (incPassengers == 0) break;

                }
            }
            input = Console.ReadLine();
        }
        System.Console.WriteLine(string.Join(' ', wagons));
    }
}