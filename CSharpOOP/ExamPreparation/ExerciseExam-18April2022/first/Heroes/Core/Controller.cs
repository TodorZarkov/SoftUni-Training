namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Repositories.Contracts;
    using Heroes.Utilities.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using weapons.Repositories;

    public class Controller : IController
    {

        IRepository<IHero> heroes;
        IRepository<IWeapon> weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository(); 
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if(heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            object item = Factory.Produce(type, new object[] { name, health, armour });
            if(item == null)
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = (IHero)item;
            heroes.Add(hero);
            if (hero.GetType().Name == "Knight")
            {
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if(weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            object item = Factory.Produce(type, new object[] { name, durability });
            if(item == null)
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon = (IWeapon)item;
            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if(heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = heroes.FindByName(heroName);
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();
            string result =
            map.Fight(heroes.Models.Where(h =>h.IsAlive && h.Weapon != null).ToList());

            return result;
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            var orderedHeroes = heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name);

            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine($"--Weapon: {(hero.Weapon!=null?hero.Weapon.Name: "Unarmed")}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
