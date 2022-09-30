using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>();
            Console.ReadLine().Split().Select(int.Parse).ToList().ForEach(cup => cups.Enqueue(cup));
            Stack<int> bottles = new Stack<int>();
            Console.ReadLine().Split().Select(int.Parse).ToList().ForEach(bottle => bottles.Push(bottle));

            int waist = 0;
            int filledWith = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cupCapacity = cups.Peek();
                int bottle = bottles.Pop();
                filledWith += bottle;
                if (filledWith >= cupCapacity)
                {
                    waist += (filledWith - cupCapacity);
                    cups.Dequeue();
                    filledWith = 0;
                }
            }

            // here func print result
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {waist}");
        }
    }
}
