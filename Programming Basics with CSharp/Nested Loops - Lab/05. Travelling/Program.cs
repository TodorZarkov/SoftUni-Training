using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string dest = Console.ReadLine();


            while (dest != "End")
            {
                double budget = double.Parse(Console.ReadLine());

                double sum = 0;
                while (sum < budget)
                {
                    sum += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {dest}!");

                dest = Console.ReadLine();
            }
        }
    }
}
