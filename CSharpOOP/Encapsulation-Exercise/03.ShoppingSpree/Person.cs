using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Person
    {
        string name;
        decimal money;
        List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                Regex empty = new Regex(@"^\s+$");
                if(value == null || value == "" || empty.IsMatch(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        private decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
    
        public bool AddToBag(Product product)
        {
            if(Money < product.Cost)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return false;
            }
            Money -= product.Cost;
            bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
            return true;
        }

        public override string ToString()
        {
            string products = bag.Count != 0 ? String.Join(", ", bag.Select(b=>b.Name)) : "Nothing bought";
            return $"{Name} - {products}";
        }
    }
}
