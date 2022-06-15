using System;

namespace _07._Theatre_Promotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day / Age     0 <= age <= 18  18 < age <= 64   64 < age <= 122

            //Weekday       12$                 18$                12$

            //Weekend       15$                 20$                 15$

            //Holiday       5$                  12$                 10$
            double price = 0;
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            //switch (age)
            //{
            //    case int n when n is >= 0 and <= 18:
            //        if (day == "Weekday")
            //        {
            //            price = 12;
            //        }
            //        else if (day == "Weekend")
            //        {
            //            price = 15;
            //        }
            //        else if (day == "Holiday")
            //        {
            //            price = 5;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Error!");
            //        }
            //        break;
            //    case int n when n is > 18 and <= 64:
            //        if (day == "Weekday")
            //        {
            //            price = 18;
            //        }
            //        else if (day == "Weekend")
            //        {
            //            price = 20;
            //        }
            //        else if (day == "Holiday")
            //        {
            //            price = 12;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Error!");
            //        }
            //        break;
            //    case int n when n is > 64 and <= 122:
            //        if (day == "Weekday")
            //        {
            //            price = 12;
            //        }
            //        else if (day == "Weekend")
            //        {
            //            price = 15;
            //        }
            //        else if (day == "Holiday")
            //        {
            //            price = 10;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Error!");
            //        }
            //        break;
            //}

            //if (price != 0)
            //{
            //    Console.WriteLine($"{price}$");
            //}
            if (age >= 0 && age <= 18)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                else if (day == "Weekend")
                {
                    price = 15;
                }
                else if (day == "Holiday")
                {
                    price = 5;
                }
                
            }
            else if (age > 18 && age <= 64)
            {
                if (day == "Weekday")
                {
                    price = 18;
                }
                else if (day == "Weekend")
                {
                    price = 20;
                }
                else if (day == "Holiday")
                {
                    price = 12;
                }
                
            }
            else if (age > 64 && age <= 122)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                else if (day == "Weekend")
                {
                    price = 15;
                }
                else if (day == "Holiday")
                {
                    price = 10;
                }

            }
            else
            {
                Console.WriteLine("Error!");
            }
            

            if (price != 0)
            {
                Console.WriteLine($"{price}$");
            }

        }
    }
}
