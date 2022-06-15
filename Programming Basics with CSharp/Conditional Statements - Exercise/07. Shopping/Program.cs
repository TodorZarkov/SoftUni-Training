using System;

namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int card = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double cardPrice = 250;
            double cpuPrice = 0.35 * card * cardPrice;
            double ramPrice = 0.10 * card * cardPrice;

            double sum = card * cardPrice + cpu * cpuPrice + ram * ramPrice;
            if (card > cpu)
            {
                sum *= (1 - 0.15);
            }

            if (budget >= sum)
            {
                Console.WriteLine($"You have {budget - sum:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sum - budget:f2} leva more!");
            }
        }
    }
}
