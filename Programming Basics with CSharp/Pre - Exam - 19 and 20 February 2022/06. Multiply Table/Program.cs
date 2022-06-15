using System;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int d1 = num % 10;
            num /= 10;
            int d2 = num % 10;
            int d3 = num / 10;

            for (int i = 1; i <= d1; i++)
            {
                for (int j = 1; j <= d2; j++)
                {
                    for (int k = 1; k <= d3; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                        
                    }
                }
            }
        }
    }
}
