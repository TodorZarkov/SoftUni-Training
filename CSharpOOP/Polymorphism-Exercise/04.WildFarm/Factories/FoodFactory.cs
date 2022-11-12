
namespace WildFarm.Factories
{
    using WildFarm.Exceptions;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Models.Food;
    using WildFarm.Models.Interfaces;

    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(params string[] data)
        {
            string foodType = data[0];
            int quantity = int.Parse(data[1]);

            Food food;
            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;

                default:
                    throw new InvalidFoodException();
            }
            return food;
        }
    }
}
