using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, PriceAndQuantity> products = new Dictionary<string, PriceAndQuantity>();
            while (line != "buy")
            {
                string[] productData = line.Split(' ').ToArray();
                string productName = productData[0];
                double currentPrice = double.Parse(productData[1]);
                int currentQuantity = int.Parse(productData[2]);

                PriceAndQuantity pq = new PriceAndQuantity(currentPrice,currentQuantity);
                if (!products.ContainsKey(productName))
                {
                    products[productName] = pq;
                }
                else
                {
                    pq.quantity += products[productName].quantity;
                    products[productName] = pq;
                }

                line = Console.ReadLine();
            }
            products.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key} -> {kvp.Value.price*kvp.Value.quantity:f2}"));
        }

    }
    struct PriceAndQuantity
    {
        public double price;
        public int quantity;
        public PriceAndQuantity(double price, int quantity)
        {
            this.price = price;
            this.quantity = quantity;
        }
    }
}
