
namespace WildFarm.Factories.Interfaces
{
    using WildFarm.Models.Interfaces;

    public interface IFoodFactory
    {
        public IFood CreateFood(string[] foodData);
    }
}
