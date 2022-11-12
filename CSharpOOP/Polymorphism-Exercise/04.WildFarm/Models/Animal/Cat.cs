
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Cat : Feline
    {
        public Cat(string name, double weight,string livingRegion, string breed) :
            base(name, weight,livingRegion, breed, 0.30, new HashSet<string>() { "Vegetable", "Meat"})
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
