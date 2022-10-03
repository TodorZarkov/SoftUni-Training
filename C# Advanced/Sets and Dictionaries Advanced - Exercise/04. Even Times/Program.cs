using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < lines; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number,1);
                }
                numbers[number] *= -1;
            }
            int theEvenKey = numbers.OrderByDescending(kvp => kvp.Value).ToList()[0].Key;
            Console.WriteLine(theEvenKey);
        }
    }
}
