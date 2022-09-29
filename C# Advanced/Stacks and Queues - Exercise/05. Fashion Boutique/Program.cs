using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>();
            Console.ReadLine().Split().ToList().ForEach(x => clothes.Push(int.Parse(x)));
            int rackCapacity = int.Parse(Console.ReadLine());

            int usedRacks = 0;
            if (clothes.Count > 0 && clothes.Max() > 0)
            {
                usedRacks = 1;
            }
            int clothesInRack = 0;
            while (clothes.Count > 0)
            {
                clothesInRack += clothes.Peek();
                if (clothesInRack > rackCapacity)
                {
                    usedRacks++;
                    clothesInRack = clothes.Pop();
                }
                else
                {
                    clothes.Pop();
                }
            }
            Console.WriteLine(usedRacks);
        }
    }
}
