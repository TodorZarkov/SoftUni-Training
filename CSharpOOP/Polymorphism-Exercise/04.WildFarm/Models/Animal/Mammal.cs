using System.Collections.Generic;

namespace WildFarm.Models.Animal
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, double weightIncrement, HashSet<string> canEat) :
            base(name, weight, weightIncrement, canEat)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {foodEaten}]";
        }
    }
}