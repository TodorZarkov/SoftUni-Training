using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte lines = byte.Parse(Console.ReadLine());
            byte capacity = 255;
            ushort liters = 0;
            for (int i = 0; i < lines ; i++)
            {
                ushort litersPoured = ushort.Parse(Console.ReadLine());
                liters += litersPoured;
                if (liters > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    liters -= litersPoured;
                }
            }
            Console.WriteLine(liters);

        }
    }
}
