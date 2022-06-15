using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int depth = int.Parse(Console.ReadLine());
            double offTank = double.Parse(Console.ReadLine());

            double volume = length*width*depth / 1000.0;
            volume = volume - volume * offTank / 100;

            Console.WriteLine(volume);


        }
    }
}
