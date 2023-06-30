namespace _07.MinimumEditDistance
{
    using System;
    using System.IO.MemoryMappedFiles;

    internal class Program
    {
        static void Main(string[] args)
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var dp = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + deleteCost;
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        dp[row, col] = Math.Min(Math.Min(replace, delete), insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[firstStr.Length, secondStr.Length]}");
        }
    }
}
