using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int k = 1;

            while (counter <= n)
            {
                for (int j = 1; j <= k; j++)
                {
                    counter++;
                    Console.Write(counter + " ");
                    if (counter == n)
                        return;
                }
                k++;
                Console.WriteLine();

            }
        }
    }
}
