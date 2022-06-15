using System;

namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());//0-23
            int minutes = int.Parse(Console.ReadLine());//0-59

            minutes += 30;
            if (minutes > 59)
            {
                minutes %= 60;
                hours++;
            }   

            if (hours == 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
