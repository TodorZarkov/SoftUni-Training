using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetExpences = headsetPrice * (lostGames / 2);
            double mouseExpences = mousePrice * (lostGames / 3);
            double keyboardExpences = keyboardPrice * (lostGames / 6);
            double displayExpences = displayPrice * (lostGames / 12);
            double expences = headsetExpences + mouseExpences + keyboardExpences + displayExpences;

            Console.WriteLine($"Rage expenses: {expences:f2} lv. ");
        }
    }
}
