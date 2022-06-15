using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int offset = 15;//in minutes

            minutes += offset;
            if (minutes >= 60)
            {
                hours += minutes / 60;
                minutes %= 60;
                if (hours >= 24)
                {
                    hours %= 24;
                }
            }

            if (minutes/10 == 0 )
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
