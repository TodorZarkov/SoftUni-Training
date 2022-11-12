using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal
{
    internal class Owl : Bird
    {
        
        public Owl(string name, double weight, double wingSize) : 
            base(name, weight, wingSize, 0.25, new HashSet<string>() {"Meat"})
        {
        }

        public override string AskForFood()
        {
            return $"Hoot Hoot";
        }
    }
}
