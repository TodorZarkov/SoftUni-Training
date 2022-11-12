
namespace WildFarm
{
    using WildFarm.Core;
    using WildFarm.Core.Interfaces;
    using WildFarm.Factories;
    using WildFarm.Factories.Interfaces;
    using WildFarm.IO;
    using WildFarm.IO.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);
            engine.Run();
        }
    }
}
