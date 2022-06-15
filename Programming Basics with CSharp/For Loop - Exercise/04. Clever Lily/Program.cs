using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double tumblePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            bool odd = true;
            double sum = 0;
            int toys = 0;
            int sumCounter = 0;

            for (int i = 0; i < age; i++)
            {
                if (odd)
                {
                    toys++;
                    odd = false;
                }
                else
                {
                    sumCounter++;
                    sum += 10*sumCounter;
                    odd = true;
                }
            }
            sum += toys * toyPrice - sumCounter;
            double diff = sum - tumblePrice;
            if (diff >= 0 )
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(diff):f2}");
            }
        }
    }
}
