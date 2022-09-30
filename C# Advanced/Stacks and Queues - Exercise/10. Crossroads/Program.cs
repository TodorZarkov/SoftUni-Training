using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenSeconds = int.Parse(Console.ReadLine());
            int freeSeconds = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int carsPassed = 0;


            string line = Console.ReadLine();
            while (line != "END")
            {
                if (line == "green")
                {
                    int carsToPass = queue.Count;
                    int crossedIndex = GreenCycle(queue, greenSeconds);
                    if (crossedIndex == -1)
                    {
                        carsPassed += carsToPass - queue.Count;
                    }
                    else
                    {
                        string passingCar = queue.Peek();
                        int leftLength = passingCar.Length - crossedIndex;
                        if (leftLength <= freeSeconds)
                        {
                            queue.Dequeue();
                            carsPassed += carsToPass - queue.Count;
                        }
                        else
                        {
                            carsPassed += carsToPass - queue.Count;
                            string hitCar = queue.Dequeue();
                            int hitIndex = crossedIndex + freeSeconds;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{hitCar} was hit at {hitCar[hitIndex]}.");
                            return;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(line);
                }

                line = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }




        static int GreenCycle(Queue<string> queue, int seconds)
        {
            while (queue.Count > 0)
            {
                seconds -= queue.Peek().Length;
                if (seconds == 0)
                {
                    queue.Dequeue();
                    return -1;
                }
                else if (seconds < 0)
                {
                    return queue.Peek().Length + seconds;
                }
                else
                {
                    queue.Dequeue();
                }
            }
            return -1;
        }
        
    }
}
