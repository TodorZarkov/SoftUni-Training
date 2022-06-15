using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double price = 0;
            double discount = 0;
            double addDisc = 0;
            if (people % 2 == 0)
            {
                addDisc = 5;
            }


            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                    price = 4200;
                    break;
                case "Autumn":
                    price = 4200;
                    addDisc = 0;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }

            if (people <= 6)
            {
                discount = 10;
            }
            else if (people >= 7 && people <= 11)
            {
                discount = 15;
            }
            else if (people >= 12)
            {
                discount = 25;
            }

            double sum = price * (1 - discount / 100) * (1 - addDisc / 100);

            if (budget >= sum)
            {
                Console.WriteLine($"Yes! You have {budget - sum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sum - budget:f2} leva.");
            }

        }
    }
}
