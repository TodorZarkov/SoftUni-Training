namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> heroes;

        public HeroRepository()
        {
            heroes = new HashSet<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)heroes;

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heroes.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return heroes.Remove(model);
        }
    }
}
