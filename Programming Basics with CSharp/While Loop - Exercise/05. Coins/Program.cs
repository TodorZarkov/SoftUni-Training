using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double rest = double.Parse(Console.ReadLine());
            rest = rest * 100;
            int sum = (int)rest;
            int incr = 200;
            int coins = 0;

            while (sum != 0)
            {
                coins += sum / incr;
                sum = sum % incr;
                if (incr == 50)
                    incr = 20;
                else
                incr = incr / 2;
            }
            Console.WriteLine(coins);

        }
    }
}
