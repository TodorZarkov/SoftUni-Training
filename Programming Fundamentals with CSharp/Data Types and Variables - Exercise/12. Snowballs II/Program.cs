using System;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            double value = 0;
            int snow = 0;
            int time = 1;
            int quality = 0;
            for (int i = 0; i < balls; i++)
            {
                int curSnow = int.Parse(Console.ReadLine());
                int curTime = int.Parse(Console.ReadLine());
                int curQuality = int.Parse(Console.ReadLine());

                int temp = curSnow / curTime;
                //(snowballSnow / snowballTime) ^ snowballQuality
                double curValue = Math.Pow((double)temp, (double)curQuality);//here we got wrong result due to rounding


                if (curValue >= value)
                {
                    value = curValue;
                    snow = curSnow;
                    time = curTime;
                    quality = curQuality;

                }
            }
            Console.WriteLine($"{snow} : {time} = {value:f0} ({quality})");
        }
    }
}
