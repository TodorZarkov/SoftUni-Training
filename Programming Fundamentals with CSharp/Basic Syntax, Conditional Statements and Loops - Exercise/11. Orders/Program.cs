using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            string output = "";
            double totalPrice = 0;

            for (int i = 0; i < orders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsules = int.Parse(Console.ReadLine());
                double price = capsulePrice * days * capsules;
                if (i!=(orders-1))
                {
                output += $"The price for the coffee is: ${price:f2}\n";
                }
                else
                {
                    output += $"The price for the coffee is: ${price:f2}";
                }
                totalPrice += price;
            }
            Console.WriteLine(output);
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
