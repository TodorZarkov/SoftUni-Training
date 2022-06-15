using System;

namespace _03._Numbers_1___N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            for (int i = 1; i <= length; i += 3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
