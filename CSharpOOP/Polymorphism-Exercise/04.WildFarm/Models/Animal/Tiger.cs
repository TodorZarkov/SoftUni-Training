
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight,string livingRegion, string breed) :
            base(name, weight,livingRegion, breed, 1.00, new HashSet<string>() { "Meat"})
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
