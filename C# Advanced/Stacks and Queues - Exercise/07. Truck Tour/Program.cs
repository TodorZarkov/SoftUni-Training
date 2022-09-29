using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPmps = int.Parse(Console.ReadLine());
            Queue<List<int>> pumps = new Queue<List<int>>();
            for (int i = 0; i < numberOfPmps; i++)
            {
                var pump = Console.ReadLine().Split().Select(int.Parse).ToList();
                pump.Add(i);
                pumps.Enqueue(pump);
            }

            int distanceLeft = 0;
            do
            {
                distanceLeft = 0;
                foreach (var pump in pumps)
                {
                    distanceLeft += pump[0] - pump[1];
                    if (distanceLeft < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        break;
                    }
                }
            } while (distanceLeft < 0);
            Console.WriteLine(pumps.First().Last());
        }
    }
}
