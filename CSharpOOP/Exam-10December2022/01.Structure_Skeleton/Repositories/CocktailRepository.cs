namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        readonly List<ICocktail> cocktails;

        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => cocktails;


        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
