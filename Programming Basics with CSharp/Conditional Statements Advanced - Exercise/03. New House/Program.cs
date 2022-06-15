using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double discount = 0;
            double sum = 0;
            double price = 0;

            switch (flower)
            {
                case "Roses":
                    if (num > 80)
                    {
                        discount = 10;
                    }
                    price = 5;
                    break;
                case "Dahlias":
                    if (num > 90)
                    {
                        discount = 15;
                    }
                    price = 3.80;
                    break;
                case "Tulips":
                    if (num > 80)
                    {
                        discount = 15;
                    }
                    price = 2.80;
                    break;
                case "Narcissus":
                    if (num < 120)
                    {
                        discount = -15;
                    }
                    price = 3;
                    break;
                case "Gladiolus":
                    if (num < 80)
                    {
                        discount = -20;
                    }
                    price = 2.5;
                    break;

            }

            sum = num * price * (1 - discount / 100);
            if (sum <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {num} {flower} and {budget - sum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {sum - budget:f2} leva more.");
            }
        }
    }
}
