namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Factories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {

        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            object item = Factory.Produce(unitTypeName);
            if (item == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            IMilitaryUnit unit = (IMilitaryUnit)item;
            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName)){
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName)){
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            object item = Factory.Produce(weaponTypeName, new object[] {destructionLevel });
            if (item == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = (IWeapon)item;
           
            

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded,planetName, weaponTypeName );
        }

        public string CreatePlanet(string name, double budget)
        {
            if(planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");
            foreach (IPlanet planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            if(firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                return WinCombat(firstPlanet,secondPlanet);
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                return WinCombat(secondPlanet,firstPlanet);
            }
            else //X - equality between doubles !!! but rounded?
            {
                bool firstHasNuc = firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                bool secondHasNuc = secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                if ((firstHasNuc && secondHasNuc) || (!firstHasNuc && !secondHasNuc))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else if (firstHasNuc)
                {
                    return WinCombat(firstPlanet,secondPlanet);
                }
                else //if(secondHasNuc)
                {
                    return WinCombat(secondPlanet,firstPlanet);
                }
            }
        }

        public string SpecializeForces(string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        private string WinCombat(IPlanet win, IPlanet lose)
        {
            win.Spend(win.Budget / 2);
            win.Profit(lose.Budget / 2);
            win.Profit(lose.Army.Sum(a => a.Cost));
            win.Profit(lose.Weapons.Sum(w => w.Price));

            planets.RemoveItem(lose.Name);

            return String.Format(OutputMessages.WinnigTheWar, win.Name, lose.Name);
        }
    }
}
