using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int pieces = length * width;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                int takenPieces = int.Parse(input);
                pieces -= takenPieces;
                if (pieces < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{pieces} pieces are left.");
        }
    }
}
