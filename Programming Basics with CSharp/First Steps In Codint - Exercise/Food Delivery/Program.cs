using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пилешко меню – 10.35 лв.
            // Меню с риба – 12.40 лв.
            // Вегетарианско меню – 8.15 лв.
            //Напишете програма, която изчислява колко ще струва на група хора да си поръчат храна за вкъщи.
            //Групата ще си поръча и десерт, чиято цена е равна на 20 % от общата сметка(без доставката).
            //Цената на доставка е 2.50 лв и се начислява най - накрая.
            //Вход
            //От конзолата се четат 3 реда:
            // Брой пилешки менюта – цяло число в интервала[0 … 99]
            // Брой менюта с риба – цяло число в интервала[0 … 99]
            // Брой вегетариански менюта – цяло число в интервала[0 … 99]

            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.4;
            double vegMenuPrice = 8.15;
            int dessertPrice = 20;//% of all food
            double delivary = 2.5;


            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegMenus = int.Parse(Console.ReadLine());

            double totalFoodPrice = chickenMenuPrice * chickenMenus + fishMenuPrice * fishMenus + vegMenuPrice * vegMenus;
            double totalPrice = totalFoodPrice * (1 + dessertPrice / 100.0) + delivary;

            Console.WriteLine(totalPrice);

        }
    }
}
