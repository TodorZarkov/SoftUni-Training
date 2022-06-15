using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double accumulatedMoney = 0;
            double[] validMoney = { 0.1, 0.2, 0.5, 1, 2 };
            bool isValid = false;
            while (command != "Start")
            {
                if (double.TryParse(command, out double insertedMoney))
                {
                    foreach (var item in validMoney)
                    {
                        if (insertedMoney == item)
                        {
                            accumulatedMoney += insertedMoney;
                            isValid = true;
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine($"Cannot accept {insertedMoney}");
                }
                isValid = false;
                command = Console.ReadLine();
            }

            string[] validProducts = { "Nuts", "Water", "Crisps", "Soda", "Coke" };
            double[] productPrices = { 2.0, 0.7, 1.5, 0.8, 1.0 };
            command = Console.ReadLine();
            isValid = false;
            while (command != "End")
            {
                for (int i = 0; i < validProducts.Length; i++)
                {
                    if (command == validProducts[i])
                    {
                        isValid = true;
                        accumulatedMoney -= productPrices[i];
                        if (accumulatedMoney >= 0)
                        {
                            Console.WriteLine($"Purchased {command.ToLower()}");
                            break;
                        }
                        else
                        {
                            accumulatedMoney  += productPrices[i];
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Invalid product");
                }
                isValid = false;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {accumulatedMoney:f2}");
        }
    }
}
