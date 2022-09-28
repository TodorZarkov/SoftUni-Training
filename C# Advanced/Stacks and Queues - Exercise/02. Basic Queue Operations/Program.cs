using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int enqueues = data[0];
            int dequeues = data[1];
            int toCheck = data[2];

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < enqueues; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < dequeues; i++)
            {
                queue.Dequeue();
            }
            bool isPresent = queue.Contains(toCheck);
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (isPresent)
            {
                Console.WriteLine(isPresent.ToString().ToLower());
            }
            else
            {
                List<int> list = queue.ToList();
                list.Sort();
                Console.WriteLine(list.First());
            }
        }
    }
}
