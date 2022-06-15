using System;

namespace _08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            if (q > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int min = n;
                int max = n;
                for (int i = 0; i < q - 1; i++)
                {
                    n = int.Parse(Console.ReadLine());
                    if (n < min)
                        min = n;
                    if (n > max)
                        max = n;
                }
                Console.WriteLine($"Max number: {max}");
                Console.WriteLine($"Min number: {min}");
            }
        }
    }
}
