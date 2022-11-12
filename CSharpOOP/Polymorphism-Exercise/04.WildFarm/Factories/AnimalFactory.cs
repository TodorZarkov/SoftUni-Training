
namespace WildFarm.Factories
{
    
    using WildFarm.Exceptions;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Models.Animal;
    using WildFarm.Models.Interfaces;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(params string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);
            double wingSize;
            string livingRegion;
            string breed;

            Animal animal;
            switch (type)
            {
                case "Hen":
                    wingSize = double.Parse(data[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;


                case "Owl":
                    wingSize = double.Parse(data[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;


                case "Mouse":
                    livingRegion = data[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;


                case "Dog":
                    livingRegion = data[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;

                case "Cat":
                    livingRegion = data[3];
                    breed = data[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;

                case "Tiger":
                    livingRegion = data[3];
                    breed = data[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;


                default:
                    throw new InvalidAnimalException();
            }

            return animal;
        }
    }
}
