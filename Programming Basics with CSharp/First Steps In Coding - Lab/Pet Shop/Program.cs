using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFoodPrice = 2.5;
            double catFoodPrice = 4;

            int dogFoodNum = int.Parse(Console.ReadLine());
            int catFoodNum = int.Parse(Console.ReadLine());

            double totalPrice = dogFoodPrice * dogFoodNum + catFoodPrice * catFoodNum;

            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
