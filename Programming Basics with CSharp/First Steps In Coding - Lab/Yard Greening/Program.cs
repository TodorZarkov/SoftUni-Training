using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = 7.61;//bgn/m2
            int discount = 18;// %

            double area = double.Parse(Console.ReadLine());
            double discountAmmount = price * area * discount / 100;
            double totalPrice = price * area - discountAmmount;

            Console.WriteLine($"The final Price is: {totalPrice} lv.");
            Console.WriteLine($"The discount is: {discountAmmount} lv.");
        }
    }
}
