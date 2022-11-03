using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        string flourType;
        string bakingTechnique;
        int grams;

        const int minGrams = 1;
        const int maxGrams = 200;
        const double baseCalories = 2;//per gram
        Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"white"        ,1.5},
            {"wholegrain"   ,1.0},
            {"crispy"       ,0.9},
            {"chewy"        ,1.1},
            {"homemade"     ,1.0}
        };


        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        private string FlourType
        {
            get => flourType;
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower();
            }
        }
        private string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }
        public int Grams
        {
            get => grams;
            private set
            {
                if (value < minGrams || value > maxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minGrams}..{maxGrams}].");
                }
                grams = value;
            }
        }
        public double CaloriesPerGram
        {
            get { return CalculateCalories(); }
        }
        private double CalculateCalories()
        {
            return baseCalories * modifiers[flourType] * modifiers[bakingTechnique];
        }
    }
}
