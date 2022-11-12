
namespace WildFarm.Core
{
    using System;
    using WildFarm.Core.Interfaces;
    using WildFarm.IO.Interfaces;
    using WildFarm.Models.Interfaces;
    using WildFarm.Factories.Interfaces;
    using System.Collections.Generic;
    using WildFarm.Models.Animal;
    using WildFarm.Models.Food;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;

        private List<IAnimal> animals;

        private Engine()
        {
            animals = new List<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }
        public void Run()
        {
            string[] data = reader.Readline().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (data[0] != "End")
            {
                IAnimal animal = animalFactory.CreateAnimal(data);
                animals.Add(animal);

                data = reader.Readline().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IFood food = foodFactory.CreateFood(data);

                writer.WriteLine(animal.AskForFood());
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }


                data = reader.Readline().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            
            animals.ForEach(animal => writer.WriteLine(animal.ToString())); 

        }
    }
}
