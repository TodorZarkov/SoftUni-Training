using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.ShoppingSpree
{
    public class Product
    {
        decimal cost;
        string name;

        public Product(string name, decimal price)
        {
            Name = name;
            Cost = price;
        }

        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
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
    }
}
