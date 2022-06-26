using System;

namespace _01._Burger_Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countCities = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 1; i <= countCities; i++)
            {
                string city = Console.ReadLine();
                double earnedMoney = double.Parse(Console.ReadLine());
                double expences = double.Parse(Console.ReadLine());

                if (i % 3 == 0 && i % 5 != 0)
                {
                    expences = expences * 1.5;//50% over cost
                }
                if (i % 5 == 0)
                {
                    earnedMoney = earnedMoney * (1.0 - 0.1);
                }

                double cityTotal = earnedMoney - expences;

                Console.WriteLine($"In {city} Burger Bus earned {cityTotal:f2} leva.");
                total += cityTotal;
            }
            Console.WriteLine($"Burger Bus total profit: {total:f2} leva.");
        }
    }
}
