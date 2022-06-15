using System;

namespace _08._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sitcomName = Console.ReadLine();
            int sitcomLen = int.Parse(Console.ReadLine());
            int breakLen = int.Parse(Console.ReadLine());

            double lunchLen = breakLen / 8.0;
            double relaxLen = breakLen / 4.0;
            double sitcomTime = breakLen - lunchLen - relaxLen;

            if (sitcomTime >= sitcomLen)
            {
                Console.WriteLine($"You have enough time to watch {sitcomName} and left with {Math.Ceiling(sitcomTime - sitcomLen)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {sitcomName}, you need {Math.Ceiling(sitcomLen - sitcomTime)} more minutes.");
            }
        }
    }
}
