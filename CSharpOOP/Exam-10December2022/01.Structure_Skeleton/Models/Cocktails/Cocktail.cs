namespace ChristmasPastryShop.Models.Cocktails
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Cocktail : ICocktail
    {


        string name;
        string size;
        double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set
            {
                size = value;
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Small")
                {
                    price = value / 3;
                }
                else if (Size == "Middle")
                {
                    price = (value * 2) / 3;
                }
                else
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
