using System;

namespace _02._Bracelet_Stand
{
    class Program
    {
        static void Main(string[] args)
        {

            double pocketMoney = double.Parse(Console.ReadLine());
            double dailyIncome = double.Parse(Console.ReadLine());
            double expences = double.Parse(Console.ReadLine());
            double parcelPrice = double.Parse(Console.ReadLine());

            double profit = 5.0 * (pocketMoney + dailyIncome) - expences;

            if (profit >= parcelPrice)
            {
                Console.WriteLine($"Profit: {profit:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {parcelPrice-profit:f2} BGN.");
            }

        }
    }
}
