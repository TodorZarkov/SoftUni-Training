using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex validOrderRX = new Regex(@"(?<name>\%[A-Z][a-z]{2,}\%)[^\|\$\%\.]*(?<product><\w+>)[^\|\$\%\.]*(?<quantity>\|\d+\|)[^\|\$\%\.]*(?<price>\b\d+\.?\d+\$)");
            string line = Console.ReadLine();
            double total = 0;
            while (line != "end of shift")
            {
                Match validOrder = validOrderRX.Match(line);
                if (!validOrder.Success)
                {
                    line = Console.ReadLine();
                    continue;
                }
                string name = validOrder.Groups["name"].Value.Trim('%');
                string product = validOrder.Groups["product"].Value.TrimStart('<').TrimEnd('>');
                int quantity = int.Parse(validOrder.Groups["quantity"].Value.Trim('|'));
                double price = double.Parse(validOrder.Groups["price"].Value.TrimEnd('$'));
                double totalPrice = price * quantity;
                total += totalPrice;
                Console.WriteLine($"{name}: {product} - {totalPrice:f2}");

                line = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
