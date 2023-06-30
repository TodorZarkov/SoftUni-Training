namespace _01.Trains
{
    using System;
    using System.Linq;

    internal class Program
    {
       
        static void Main(string[] args)
        {
            var  arrival = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .OrderBy(a => a)
            .ToArray();

           var departure = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(d => d)
                .ToArray();

            var platforms = 0;
            var currentPlatforms = 0;
            var arvIndex = 0;
            var dprIndex = 0;
            while (arvIndex < arrival.Length && dprIndex < arrival.Length)
            {
                if (arrival[arvIndex] < departure[dprIndex])
                {
                    currentPlatforms++;
                    arvIndex++;
                    platforms = Math.Max(currentPlatforms, platforms);
                }
                else
                {
                    currentPlatforms--;
                    dprIndex++;
                }
            }

            Console.WriteLine(platforms);
        }

       
    }
}
