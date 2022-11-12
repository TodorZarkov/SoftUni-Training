
namespace WildFarm.Models.Animal
{
    using System.Collections.Generic;
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) :
            base(name, weight, wingSize, 0.35, new HashSet<string>() { "Vegetable", "Fruit", "Meat", "Seeds" })
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
