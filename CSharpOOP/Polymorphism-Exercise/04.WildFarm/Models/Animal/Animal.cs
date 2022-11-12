
namespace WildFarm.Models.Animal
{

    using Interfaces;
    using Food;
    using System;
    using WildFarm.Models.Exceptions;
    using System.Collections.Generic;

    public abstract class Animal : IAnimal
    {
        protected int foodEaten;
        double weightIncrement;
        HashSet<string> canEat;



        protected Animal()
        {
            foodEaten = 0;
        }
        protected Animal(string name, double weight, double weightIncrement, HashSet<string> canEat) : this()
        {
            Name = name;
            Weight = weight;
            this.weightIncrement = weightIncrement;
            this.canEat = canEat;
        }




        public string Name { get; private set; }

        public double Weight { get; private set; }




        public abstract string AskForFood();


        public void Eat(IFood food)
        {
            if (!CanEat(food)) 
            { 
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalDoesNotEatFood, this.GetType().Name, food.GetType().Name)); 
            }

            foodEaten += food.Quantity;
            Weight += food.Quantity * weightIncrement;
            
        }


        protected  bool CanEat(IFood food)
        {
            if (!canEat.Contains(food.GetType().Name))
            {
                return false;
            }
            return true;
        }

        //public override abstract string ToString();
    }
}
