using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                string[] clothData = Console.ReadLine().Split(" -> ");
                string color = clothData[0];
                string[] items = clothData[1].Split(',');
                foreach (string item in items)
                {
                    if (!colors.ContainsKey(color))
                    {
                        colors.Add(color, new Dictionary<string, int>());
                    }
                    if (!colors[color].ContainsKey(item))
                    {
                        colors[color].Add(item, 0);
                    }
                    colors[color][item]++;
                }
            }
            string[] toFind = Console.ReadLine().Split();
            string toFindColor = toFind[0];
            string toFindCloth = toFind[1];

            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Key} clothes:");
                color.Value.ToList().ForEach(cloth =>
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color.Key == toFindColor && cloth.Key == toFindCloth)
                    {
                        Console.Write($" (found!)");
                    }
                    Console.WriteLine();
                });
            }
        }
    }
}
