
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) :
            base(name, weight, livingRegion, 0.40, new HashSet<string>() { "Meat" })
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
