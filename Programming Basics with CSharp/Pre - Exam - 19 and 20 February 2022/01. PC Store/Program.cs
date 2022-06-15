using System;

namespace _01._PC_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double usdCpuPrice = double.Parse(Console.ReadLine());
            double usdVideoPrice = double.Parse(Console.ReadLine());
            double usdRamPrice = double.Parse(Console.ReadLine());
            int numRam = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double bgnPrice = (1.57 * usdCpuPrice) * (1.0 - discount) + (1.57 * usdVideoPrice) * (1.0 - discount) + 1.57 * numRam * usdRamPrice;
            Console.WriteLine($"Money needed - {bgnPrice:f2} leva. ");




        }
    }
}
