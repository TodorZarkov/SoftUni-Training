using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apPrice = 0;
            int discountSt = 0;
            int discountAp = 0;
            if (nights > 14)
                discountAp = 10;

            switch (month)
            {
                case "May":
                case "October":
                    if (nights > 7 && nights <= 14)
                        discountSt = 5;
                    else if (nights > 14)
                        discountSt = 30;
                    studioPrice = 50;
                    apPrice = 65;
                        break;

                case "June":
                case "September":
                    if (nights > 14)
                        discountSt = 20;
                    studioPrice = 75.2;
                    apPrice = 68.7;
                    break;

                case "July":
                case "August":
                    studioPrice = 76;
                    apPrice = 77;
                    break;
            }
            apPrice *= nights * (1 - discountAp / 100.0);
            studioPrice *= nights * (1 - discountSt / 100.0);
            Console.WriteLine($"Apartment: {apPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
