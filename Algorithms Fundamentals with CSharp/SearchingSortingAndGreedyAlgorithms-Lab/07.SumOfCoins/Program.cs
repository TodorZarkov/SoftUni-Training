namespace _07.SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(c => c);
            var coins = new Queue<int>(input);

            var target = int.Parse(Console.ReadLine());

            var usedCoins = new Dictionary<int, int>();
            var totalCoins = 0;

            while (target > 0 && coins.Count  > 0)
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;

                if (count  == 0)
                {
                    continue;
                }

                usedCoins[currentCoin] = count;
                totalCoins += count;

                target %= currentCoin;
            }
            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");
                foreach (var coin in usedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            
        }
    }
}
