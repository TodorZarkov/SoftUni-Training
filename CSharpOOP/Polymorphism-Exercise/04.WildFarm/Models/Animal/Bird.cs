
using System.Collections.Generic;

namespace WildFarm.Models.Animal
{

    public abstract class Bird : Animal
    {

        protected Bird(string name, double weight, double wingSize, double weightIncrement, HashSet<string> canEat) 
            : base(name, weight, weightIncrement, canEat)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {foodEaten}]";
        }
    }
}
