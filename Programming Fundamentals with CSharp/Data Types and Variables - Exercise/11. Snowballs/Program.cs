using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            BigInteger value = 0;
            BigInteger snow = 0;
            BigInteger time = 1;
            int quality = 0;
            for (int i = 0; i < balls; i++)
            {
                BigInteger curSnow = int.Parse(Console.ReadLine());
                BigInteger curTime = int.Parse(Console.ReadLine());
                int curQuality = int.Parse(Console.ReadLine());

                BigInteger curValue = BigInteger.Pow((curSnow / curTime), curQuality);
                
                if (curValue >= value)
                {
                    value =  curValue;
                    snow = curSnow;
                    time = curTime;
                    quality = curQuality;

                }
            }
            Console.WriteLine($"{snow} : {time} = {value} ({quality})");
        }
    }
}
