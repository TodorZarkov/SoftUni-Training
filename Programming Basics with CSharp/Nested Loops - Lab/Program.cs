using System;
using System.Threading;

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
                    for (int i = 0; i < 60; i++)
                    {

                    Console.WriteLine($"{hour:d2}:{min:d2}:{i:d2}");
                        Thread.Sleep(1000);
                    }

                }

            }

        }
    }
}
