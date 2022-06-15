using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());//days
            int nights = --days;
            string roomType = Console.ReadLine();
            string eval = Console.ReadLine();
            double price = 18;
            int discount = 0;



            switch (roomType)
            {
                case "apartment":
                    price = 25;
                    if (days < 10)
                    {
                        discount = 30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 35;
                    }
                    else if (days > 15)
                    {
                        discount = 50;
                    }
                    break;

                case "president apartment":
                    price = 35;
                    if (days < 10)
                    {
                        discount = 10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 15;
                    }
                    else if (days > 15)
                    {
                        discount = 20;
                    }
                    break;
            }
            price *= (1 - discount / 100.0) * nights;
            switch (eval)
            {
                case "positive":
                    price *= (1 + 0.25);
                    break;
                case "negative":
                    price *= (1 - 0.10);
                    break;
            }
            Console.WriteLine($"{price:f2}") ;
        }
    }
}
