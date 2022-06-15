using System;

namespace _11._Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quontity = double.Parse(Console.ReadLine());

            //плод banana apple   orange  grapefruit  kiwi    pineapple   grapes
            //цена 2.50   1.20    0.85    1.45        2.70    5.50        3.85

            //Събота и неделя магазинът работи на по - високи цени:
            //плод banana apple   orange  grapefruit  kiwi    pineapple   grapes
            //цена 2.70   1.25    0.90    1.60        3.00    5.60        4.20

            double price = 0;

            switch (fruit)
            {
                case "banana":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 2.5;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 2.70;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "apple":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 1.20;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 1.25;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "orange":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 0.85;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 0.90;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "grapefruit":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 1.45;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 1.60;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "kiwi":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 2.70;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 3;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "pineapple":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 5.50;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 5.60;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "grapes":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = 3.85;
                            break;
                        case "Sunday":
                        case "Saturday":
                            price = 4.20;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;

            }
            if (price != 0)
            {
                Console.WriteLine($"{price * quontity:f2}");
            }
        }
    }
}
