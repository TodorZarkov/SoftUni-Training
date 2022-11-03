using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        string type;
        int grams;

        const int minGrams = 1;
        const int maxGrams = 50;
        const double baseCalories = 2;//per gram
        Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"meat"    ,1.2},
            {"veggies" ,0.8},
            {"cheese"  ,1.1},
            {"sauce"   ,0.9}
        };

        public Topping(string type, int grams)
        {
            Type = type;
            Grams = grams;
        }

        private string Type 
        { 
            get => type; 
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value.ToLower();
            }
        }
        public int Grams 
        { 
            get => grams; 
            private set
            {
                if(value < minGrams || value > maxGrams)
                {
                    throw new ArgumentException($"{Type[0].ToString().ToUpper()+Type.Remove(0,1)} weight should be in the range [{minGrams}..{maxGrams}].");
                }
                grams = value;
            } 
        }
        public double CaloriesPerGram { get => CalculateCalories();}
        private double CalculateCalories()
        {
            return baseCalories * modifiers[Type];  
        }
    }
}
