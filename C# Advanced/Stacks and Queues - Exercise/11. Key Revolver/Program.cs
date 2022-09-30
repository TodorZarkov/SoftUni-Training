using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine()); //[0-100]
            int barrelSize = int.Parse(Console.ReadLine());//[1-5000]
            Stack<int> bullets = new Stack<int>();
            Console.ReadLine().Split().Select(int.Parse).ToList().ForEach(bullet => bullets.Push(bullet));
            Queue<int> locks = new Queue<int>();
            Console.ReadLine().Split().Select(int.Parse).ToList().ForEach(loc => locks.Enqueue(loc));
            int intelValue = int.Parse(Console.ReadLine());
            int countBullets = 0;

            while (locks.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }



                int bullet = bullets.Pop();
                intelValue -= bulletPrice;
                countBullets++;
                int loc = locks.Peek();
                if (bullet <= loc)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countBullets == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    countBullets = 0;
                }
            }
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelValue}");

        }
    }
}
