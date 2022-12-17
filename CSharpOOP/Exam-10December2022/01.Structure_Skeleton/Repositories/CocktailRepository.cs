namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly ICollection<ICocktail> cocktails;

        public CocktailRepository()
        {
            cocktails = new HashSet<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => (IReadOnlyCollection<ICocktail>)cocktails;


        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
