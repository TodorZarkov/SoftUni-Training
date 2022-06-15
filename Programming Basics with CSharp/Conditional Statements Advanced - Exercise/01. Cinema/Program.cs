using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            double income = row * col;

            if (ticketType == "Premiere")
            {
                income = income * 12;
            }
            else if (ticketType == "Normal")
            {
                income = income * 7.5;
            }
            else
            {
                income = income * 5;
            }

            Console.WriteLine("{0:f}", income);
        }
    }
}

