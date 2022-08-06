using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            List<string> furniture = new List<string>();
            Regex rx = new Regex(@"(^>>(?<name>[a-zA-Z\s]+)<<(?<price>\d+\.{0,1}\d+)!(?<quantity>\d+))");
            string line = Console.ReadLine();
            while (line != "Purchase")
            {
                Match matchedLine = rx.Match(line);
                if (!matchedLine.Success)
                {
                    line = Console.ReadLine();
                    continue;
                }
                string name = matchedLine.Groups["name"].Value;
                furniture.Add(name);
                int quantity = int.Parse(matchedLine.Groups["quantity"].Value);
                double price = double.Parse(matchedLine.Groups["price"].Value);
                total = total + price * quantity;

                line = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            furniture.ForEach(f => Console.WriteLine(f));
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
