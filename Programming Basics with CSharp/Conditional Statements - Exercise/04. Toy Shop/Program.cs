using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пъзел -          2.60  лв.
            // Говореща кукла  -3     лв.
            // Плюшено мече    -4.10  лв.
            // Миньон -         8.20  лв.
            // Камионче -       2     лв.

            double tripPrice = double.Parse(Console.ReadLine());

            int puzzleQuontity = int.Parse(Console.ReadLine());
            int dollQuontity = int.Parse(Console.ReadLine());
            int bearQuontity = int.Parse(Console.ReadLine());
            int minionQuontity = int.Parse(Console.ReadLine());
            int truckQuontity = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollPrice = 3;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            double discount = 0;//percent of the tottal price
            double rent = 10;//percent of the total price



            int totalQuontity = puzzleQuontity + dollQuontity + bearQuontity + minionQuontity + truckQuontity;
            if (totalQuontity >= 50)
                discount = 25;

            double total = puzzleQuontity * puzzlePrice + dollQuontity * dollPrice + bearQuontity * bearPrice + minionPrice * minionQuontity + truckPrice * truckQuontity;
            total = total * (1 - discount / 100.0);
            total = total * (1 - rent / 100.0);

            double diff = total - tripPrice;
            if (diff >= 0)
            {
                Console.WriteLine($"Yes! {diff:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(-1*diff):f2} lv needed.");
            }



        }
    }
}
