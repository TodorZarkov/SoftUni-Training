using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayType = Console.ReadLine();

            decimal price = 0;

            if (dayType == "Friday")
            {
                if (groupType == "Students")
                {
                    price = numberOfPeople * 8.45m;
                    if (numberOfPeople >= 30)
                    {
                        price = price - price * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = numberOfPeople * 10.90m;
                    if (numberOfPeople >= 100)
                    {
                        price = price - price / numberOfPeople * 10;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = numberOfPeople * 15m;
                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        price = price - price * 0.05m;
                    }
                }
            }
            else if (dayType == "Saturday")
            {
                if (groupType == "Students")
                {
                    price = numberOfPeople * 9.80m;
                    if (numberOfPeople >= 30)
                    {
                        price = price - price * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = numberOfPeople * 15.60m;
                    if (numberOfPeople >= 100)
                    {
                        price = price - price / numberOfPeople * 10;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = numberOfPeople * 20m;
                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        price = price - price * 0.05m;
                    }
                }
            }
            else if (dayType == "Sunday")
            {
                if (groupType == "Students")
                {
                    price = numberOfPeople * 10.46m;
                    if (numberOfPeople >= 30)
                    {
                        price = price - price * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = numberOfPeople * 16.00m;
                    if (numberOfPeople >= 100)
                    {
                        price = price - price / numberOfPeople * 10;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = numberOfPeople * 22.50m;
                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        price = price - price * 0.05m;
                    }
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
