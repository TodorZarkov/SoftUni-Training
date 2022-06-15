using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int points = 0;
            string variant = "";
            int wins = 0;
            // W - ако е победител получава 2000 точки
            // F - ако е финалист получава 1200 точки
            // SF - ако е полуфиналист получава 720 точки
            for (int i = 0; i < n; i++)
            {
                variant = Console.ReadLine();
                switch (variant)
                {
                    case "W":
                        points += 2000;
                        wins++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }
            Console.WriteLine($"Final points: {points+startPoints}");
            Console.WriteLine($"Average points: {Math.Floor(1.0*points/n)}");
            Console.WriteLine($"{100.0*wins/n:f2}%");
        }
    }
}
