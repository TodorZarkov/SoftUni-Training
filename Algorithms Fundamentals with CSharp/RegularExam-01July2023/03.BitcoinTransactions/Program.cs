namespace _03.BitcoinTransactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var firstString = Console.ReadLine()
                .Split()
                .Select(s => s.Trim())
                .ToArray();

            var secondString = Console.ReadLine()
                .Split()
                .Select(s => s.Trim())
                .ToArray();

            var lcs = new int[firstString.Length + 1, secondString.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (firstString[r - 1] == secondString[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            //Print(lcs);


            Stack<string> path = new Stack<string>();
            int row = lcs.GetLength(0) - 1;
            int col = lcs.GetLength(1) - 1;
            while (row > 0 && col > 0)
            {
                if (lcs[row, col - 1] > lcs[row - 1, col])
                {
                    col--;
                }
                else if (lcs[row, col - 1] < lcs[row - 1, col])
                {
                    row--;
                }
                else
                {
                    if (firstString[row - 1] == secondString[col - 1])
                    {
                        path.Push($"{firstString[row - 1]}");
                    }
                    row--;

                }
            }

            //Console.WriteLine(lcs[firstString.Length, secondString.Length]);
            Console.WriteLine($"[{string.Join(" ", path)}]");
        }

        private static void Print(int[,] lcs)
        {
            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    Console.Write($"{lcs[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
