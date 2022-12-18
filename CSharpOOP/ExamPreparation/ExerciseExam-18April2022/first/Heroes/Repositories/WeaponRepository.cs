namespace weapons.Repositories
{
    
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)weapons;

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return weapons.Remove(model);
        }
    }
}

