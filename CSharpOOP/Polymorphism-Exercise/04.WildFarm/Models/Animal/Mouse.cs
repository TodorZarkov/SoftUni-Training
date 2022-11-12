
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) :
            base(name, weight, livingRegion, 0.10, new HashSet<string>() { "Vegetable", "Fruit" })
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
