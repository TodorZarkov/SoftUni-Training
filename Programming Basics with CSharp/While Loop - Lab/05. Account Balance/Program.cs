using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string money = Console.ReadLine();
            double currMoney = 0;
            while (money != "NoMoreMoney")
            {
                currMoney = double.Parse(money);
                if (currMoney < 0 )
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += currMoney;
                Console.WriteLine($"Increase: {currMoney:f2}");
                money = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
