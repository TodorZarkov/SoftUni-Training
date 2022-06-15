using System;

namespace _03._Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;

            switch (season)
            {
                case "spring":
                    if (persons<=5)
                    {
                        price = persons * 50.0;
                    }
                    else
                    {
                        price = persons * 48.0;
                    }
                    break;
                case "summer":
                    if (persons <= 5)
                    {
                        price = persons * 48.5;
                    }
                    else
                    {
                        price = persons * 45.0;
                    }
                    price *= (1 - 0.15);
                    break;
                case "autumn":
                    if (persons <= 5)
                    {
                        price = persons * 60.0;
                    }
                    else
                    {
                        price = persons * 49.5;
                    }
                    break;
                case "winter":
                    if (persons <= 5)
                    {
                        price = persons * 86.0;
                    }
                    else
                    {
                        price = persons * 85.0;
                    }
                    price *= (1 + 0.08);
                    break;
            }
            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
