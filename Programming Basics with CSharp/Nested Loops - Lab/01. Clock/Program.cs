using System;

namespace Nested_Loops___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int min = 0; min < 60; min++)
                {

                    Console.WriteLine($"{hour:d2}:{min:d2}");
                }
            }
        }
    }
}
