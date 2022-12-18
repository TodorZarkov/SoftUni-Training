namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private readonly IRepository<IMilitaryUnit> units;
        private readonly IRepository<IWeapon> weapons;
        private string name;
        private double budget;

        private Planet()
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }
        public Planet(string name, double budget) : this()
        {
            Name = name;
            Budget = budget;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double total = units.Models.Sum(u => u.EnduranceLevel) +
                    weapons.Models.Sum(w => w.DestructionLevel);
                if (units.Models.Any(m => m.GetType().Name == "AnonymousImpactUnit"))
                {
                    total *= 1.3;
                }
                if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    total *= 1.45;
                }
                return Math.Round(total, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            string unitsToPrint = units.Models.Any() ? String.Join(", ", units.Models.Select(u => u.GetType().Name)) : "No units";

            string weaponsToPrint = weapons.Models.Any() ? String.Join(", ", weapons.Models.Select(w => w.GetType().Name)) : "No weapons";


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {unitsToPrint}");
            sb.AppendLine($"--Combat equipment: {weaponsToPrint}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            double decreacedBudget = Budget - amount;
            if (decreacedBudget < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget = decreacedBudget;
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
