using System;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            int value = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;
            for (int i = 0; i < balls; i++)
            {
                snow = int.Parse(Console.ReadLine());
                time = int.Parse(Console.ReadLine());
                quality = int.Parse(Console.ReadLine());

                int curValue = (snow / time) ^ quality;
                if (curValue > value)
                {
                    value = curValue;
                }
            }
            Console.WriteLine($"{snow} : {time} = {value} ({quality})");
        }
    }
}
