using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceSaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double priceSabers = priceSaber * (countOfStudents + Math.Ceiling(countOfStudents * 0.1));
            double priceRobes = priceRobe * countOfStudents;
            double priceBelts = priceBelt * (countOfStudents - countOfStudents / 6);

            double spentMoney = priceSabers + priceBelts + priceRobes;

            if (spentMoney <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {spentMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(spentMoney-money):F2}lv more.");
            }
        }
    }
}
