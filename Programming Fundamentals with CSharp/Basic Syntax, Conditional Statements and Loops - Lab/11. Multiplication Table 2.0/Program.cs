using System;

namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int mult = int.Parse(Console.ReadLine());
            if (mult > 10)
            {
                Console.WriteLine($"{number} X {mult} = {number * mult}");
            }
            else
            {
                for (int i = mult; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {i} = {number * i}");
                }

            }
        }
    }
}
