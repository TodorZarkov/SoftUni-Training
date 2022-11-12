
namespace WildFarm.Models.Interfaces
{
    
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }


        public string AskForFood();

        public void Eat(IFood food);

    }
}
