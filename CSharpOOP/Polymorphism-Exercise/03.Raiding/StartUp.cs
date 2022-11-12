 
namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfValidHeroes = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < numberOfValidHeroes)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    BaseHero hero = CreateHero(name, type);
                    heroes.Add(hero);
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }

            decimal bossPower = decimal.Parse(Console.ReadLine());

            heroes.ForEach(hero => Console.WriteLine(hero.CastAbility()));

            if (bossPower <= heroes.Sum(h => h.Power))
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        private static BaseHero CreateHero(string name, string type)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);

                case "Paladin":
                    return new Paladin(name);

                case "Rogue":
                    return new Rogue(name);

                case "Warrior":
                    return new Warrior(name);

                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
