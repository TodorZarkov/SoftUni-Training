using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.PizzaCalories
{
    internal class Pizza
    {
        const int minNameLength = 1;
        const int maxNameLength = 15;
        const int minNumberOfToppings = 0;
        const int maxNumberOfToppings = 10;
        List<Topping> toppings;
        string name;
        Dough dough;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Regex empty = new Regex(@"^\s+^");
                if (value == null || value == "" || empty.IsMatch(value))
                {
                    throw new ArgumentException($"Pizza name should be between {minNameLength} and {maxNameLength} symbols.");
                }
                if (value.Length < minNameLength || value.Length > maxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {minNameLength} and {maxNameLength} symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            set
            {
                dough = value;
            }
        }
        public int NumberOfToppings { get => toppings.Count; }
        public double TotalCalories { get => CalcTotalCalories(); }
        private double CalcTotalCalories()
        {
            double result = 0;
            if (dough != null)
                result = dough.CaloriesPerGram * dough.Grams;
            if (toppings.Count != 0)
                toppings.ForEach(t => result += t.CaloriesPerGram * t.Grams);
            return result;
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= maxNumberOfToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{minNumberOfToppings}..{maxNumberOfToppings}].");
            }
            toppings.Add(topping);
        }
    }
}
