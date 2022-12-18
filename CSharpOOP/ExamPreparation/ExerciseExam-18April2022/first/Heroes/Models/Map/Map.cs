namespace Heroes.Models.Map
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.
                Where(p => p.GetType().Name == "Knight" && p.IsAlive).
                ToList();

            List<IHero> barbarians = players.
                Where(p => p.GetType().Name == "Barbarian" && p.IsAlive).
                ToList();

            int countOfKnights = knights.Count;
            int countOfBarbarians = barbarians.Count;

            while (knights.Count != 0 && barbarians.Count != 0)
            {
                foreach (var knight in knights)
                {
                    barbarians.ForEach(b => b.TakeDamage(knight.Weapon.DoDamage()));
                    barbarians.RemoveAll(b => !b.IsAlive);
                    if (barbarians.Count == 0)
                    {
                        break;
                    }
                }
                if (barbarians.Count == 0)
                {
                    break;
                }

                foreach (var barbarian in barbarians)
                {
                    knights.ForEach(k => k.TakeDamage(barbarian.Weapon.DoDamage()));
                    knights.RemoveAll(k => !k.IsAlive);
                    if (knights.Count == 0)
                    {
                        break;
                    }
                }
            }

            if (barbarians.Count == 0)
            {
                return $"The knights took {countOfKnights - knights.Count} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {countOfBarbarians - barbarians.Count} casualties but won the battle.";
            }
        }
    }
}
