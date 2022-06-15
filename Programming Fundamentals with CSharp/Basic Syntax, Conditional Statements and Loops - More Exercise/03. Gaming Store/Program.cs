using System;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double initilaBudget = budget;
            string[] validGames = { "OutFall 4", "CS: OG", "Zplinter Zell", "Honored 2", "RoverWatch", "RoverWatch Origins Edition" };
            double[] productPrices = { 39.99, 15.99, 19.99, 59.99, 29.99, 39.99 };
            bool isValid = false;
            string command = Console.ReadLine();
            while (command != "Game Time")
            {
                for (int i = 0; i < validGames.Length; i++)
                {
                    if (command == validGames[i])
                    {
                        isValid = true;
                        budget -= productPrices[i];
                        if (budget >= 0)
                        {
                            Console.WriteLine($"Bought {command}");
                            if (budget == 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                            break;
                        }
                        else
                        {
                            budget += productPrices[i];
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Not Found");
                }
                isValid = false;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${(initilaBudget-budget):f2}. Remaining: ${budget:f2}");
        }
    }
}
