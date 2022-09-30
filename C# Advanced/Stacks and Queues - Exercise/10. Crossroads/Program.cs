using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int yellowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string line = Console.ReadLine();
            int carsPassed = 0;
            while (line != "END")
            {
                if (line == "green")
                {
                    carsPassed += queue.Count;
                    int crossing = Crossing(greenDuration, yellowDuration, queue);
                    if(crossing != 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{queue.Peek()} was hit at {(char)crossing}.");
                        return;
                    }
                }
                else
                {
                    queue.Enqueue(line);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }





        static int Crossing(int greenDuration, int yellowDuration, Queue<string> queue)
        {
            string car = "";
            while (greenDuration > 0 && queue.Count > 0)//(duration in seconds)
            {
                greenDuration -= queue.Peek().Length;
                if(greenDuration >= 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Count == 0)
                return 0;

            if (greenDuration == 0)
                return 0;

            int index = Math.Abs(greenDuration);
            if (index > car.Length - 1)
            {
                queue.Dequeue();
                return 0;
            }
               

            return (int)car[index];
        }
    }
}
