
namespace WildFarm.Models.Animal
{
    using System.Collections.Generic;
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed, double weightIncrement, HashSet<string> canEat) :
            base(name, weight, livingRegion, weightIncrement, canEat)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {foodEaten}]";
        }

    }
}
