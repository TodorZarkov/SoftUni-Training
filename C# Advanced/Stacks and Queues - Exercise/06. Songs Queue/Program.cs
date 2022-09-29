using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>();
            Console.ReadLine().Split(", ").ToList().ForEach(x => songs.Enqueue(x));
            while (songs.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(' ', 2);
                switch (commands[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        if (!songs.Contains(commands[1]))
                        {
                            songs.Enqueue(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ",songs));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
