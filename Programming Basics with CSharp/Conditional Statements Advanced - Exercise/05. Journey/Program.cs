using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string dest = "";
            double sum = 0;
            string type = "";

            if (budget <= 100)
            {
                dest = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        sum = 0.30 * budget;
                        type = "Camp";
                        break;
                    case "winter":
                        sum = 0.70 * budget;
                        type = "Hotel";
                        break;
                }
            }
            else if (budget <= 1000)
            {
                dest = "Balkans";
                switch (season)
                {
                    case "summer":
                        sum = 0.40 * budget;
                        type = "Camp";
                        break;
                    case "winter":
                        sum = 0.80 * budget;
                        type = "Hotel";
                        break;
                }
            }
            else if (budget > 1000)
            {
                dest = "Europe";
                sum = 0.90 * budget;
                type = "Hotel";
            }

            Console.WriteLine($"Somewhere in {dest}");
            Console.WriteLine($"{type} - {sum:f2}");
        }
    }
}
