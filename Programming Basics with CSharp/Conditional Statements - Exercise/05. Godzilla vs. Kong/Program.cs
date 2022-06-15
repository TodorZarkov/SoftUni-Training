using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int actors = int.Parse(Console.ReadLine());
            double dressPrice = double.Parse(Console.ReadLine());

            int decorePrice = 10;//percent off the movie
            int dressDiscount = 0;//percent off the dressPrice

            if (actors > 150)
            {
                dressDiscount = 10;
            }

            double expences = budget * decorePrice / 100.0   +   actors * dressPrice * (1 - dressDiscount / 100.0);


            if (budget >= expences)
            {
                Console.WriteLine("Action!");
                Console.WriteLine("Wingard starts filming with {0:f2} leva left.", budget - expences);
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine("Wingard needs {0:f2} leva more.", expences - budget);
            }

        }
    }
}
