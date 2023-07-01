namespace _01.BitcoinMiners
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<int, long> binoms;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            binoms = new Dictionary<int, long>();

            Console.WriteLine(GetBinom(n, k));
        }

        private static long GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1L;
            }

            long result;
            int key = HashCode.Combine<int, int>(row, col);
            if (binoms.ContainsKey(key))
            {
                result = binoms[HashCode.Combine<int, int>(row, col)];
            }
            else
            {
                result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
                binoms.Add(key, result);
            }

            return result;
        }
    }
}
