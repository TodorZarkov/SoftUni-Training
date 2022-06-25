using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> fDeck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> sDeck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (fDeck.Count != 0 && sDeck.Count != 0)
            {
                if (fDeck[0] > sDeck[0])
                {
                    fDeck.Add(sDeck[0]);
                    fDeck.Add(fDeck[0]);
                    fDeck.RemoveAt(0);
                    sDeck.RemoveAt(0);
                }
                else if (fDeck[0] < sDeck[0])
                {
                    sDeck.Add(fDeck[0]);
                    sDeck.Add(sDeck[0]);
                    sDeck.RemoveAt(0);
                    fDeck.RemoveAt(0);
                }
                else
                {
                    fDeck.RemoveAt(0);
                    sDeck.RemoveAt(0);
                }
            }
            string output = fDeck.Count > sDeck.Count ? $"First player wins! Sum: {fDeck.Sum()}" : $"Second player wins! Sum: {sDeck.Sum()}";
            Console.WriteLine(output);
        }
    }
}
