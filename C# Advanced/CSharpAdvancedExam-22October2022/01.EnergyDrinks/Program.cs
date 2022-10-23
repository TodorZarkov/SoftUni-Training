using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeines = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int takenCaffeine = 0;
            while (caffeines.Count > 0 && drinks.Count > 0)
            {
                int caffeine = caffeines.Pop();
                int drink = drinks.Peek();
                int toTake = caffeine * drink;
                if (toTake+takenCaffeine <= 300)
                {
                    takenCaffeine += toTake;
                    drinks.Dequeue();
                }
                else
                {
                    takenCaffeine -= 30;
                    if (takenCaffeine < 0)
                    {
                        takenCaffeine = 0;
                    }
                    drinks.Enqueue(drinks.Dequeue());
                }
            }
            if (drinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {takenCaffeine} mg caffeine.");

        }
    }
}
