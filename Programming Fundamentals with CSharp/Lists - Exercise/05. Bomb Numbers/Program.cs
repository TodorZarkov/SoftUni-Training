using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bombNumber = bombData[0];
            int bombRadius = bombData[1];

            int index = numbers.IndexOf(bombNumber);
            while (index != -1)
            {
                int removeIndex = index - bombRadius;
                if (removeIndex < 0) removeIndex = 0;
                int endIndex = index + bombRadius;
                if (endIndex >= numbers.Count) endIndex = numbers.Count - 1;
                int countToRemove = endIndex - removeIndex + 1;
                numbers.RemoveRange(removeIndex, countToRemove);

                index = numbers.IndexOf(bombNumber);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
