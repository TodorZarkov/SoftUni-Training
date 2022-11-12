namespace WildFarm.Models.Food
{
    
    using Models.Interfaces;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
