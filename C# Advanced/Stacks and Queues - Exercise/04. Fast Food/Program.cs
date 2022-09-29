using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>();
            Console.ReadLine().Split().Select(int.Parse).ToList().ForEach(x => orders.Enqueue(x));
            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                quantityFood -= orders.Peek();
                if (quantityFood < 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(' ',orders)}");
                    return;
                }
                orders.Dequeue();
            }
            Console.WriteLine("Orders complete");
        }
    }
}
