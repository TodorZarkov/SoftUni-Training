using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            try
            {
                personList = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).Select(p => p.Split('=', StringSplitOptions.RemoveEmptyEntries)).Select(p => new Person(p[0], decimal.Parse(p[1]))).ToList();

                productList = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).Select(p => p.Split('=', StringSplitOptions.RemoveEmptyEntries)).Select(p => new Product(p[0], decimal.Parse(p[1]))).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Dictionary<string, Person> people = personList.ToDictionary(p => p.Name);
            Dictionary<string, Product> market = productList.ToDictionary(p => p.Name);

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] shopData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = shopData[0];
                string productName = shopData[1];

                if (!people.ContainsKey(name) || !market.ContainsKey(productName))
                {
                    line = Console.ReadLine();
                    continue;
                }

                var person = people[name];
                var product = market[productName];
                person.AddToBag(product);

                line = Console.ReadLine();
            }
            personList.ForEach(Console.WriteLine);

        }
    }
}
