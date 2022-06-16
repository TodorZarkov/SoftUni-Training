using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initIyeld = int.Parse(Console.ReadLine());
            long totalIyeld = 0;
            int minSpices = 100;
            int expectedSpice = initIyeld;
            int day = 0;
            while (expectedSpice >= minSpices)
            {
                day++;
                totalIyeld += expectedSpice - 26;
                expectedSpice -= 10;
            }
            if (totalIyeld!=0)
            {
            totalIyeld -= 26;
            }
            Console.WriteLine(day);
            Console.WriteLine(totalIyeld);
        }
    }
}
