using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            int volume = width * length * hight;

            string input = Console.ReadLine();

            while (input != "Done")
            {
                int takenVolume = int.Parse(input);
                volume -= takenVolume;
                if (volume < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{volume} Cubic meters left.");
        }
    }
}
