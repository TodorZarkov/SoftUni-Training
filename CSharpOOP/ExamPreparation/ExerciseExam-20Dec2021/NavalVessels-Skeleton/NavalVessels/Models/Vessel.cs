
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private double mainWeaponCaliber;
        private double speed;
        private double armorThinkness;

        private ICaptain captain;
        private List<string> targets;

        private double initArmorThickness;

        private Vessel()
        {
            targets = new List<string>();
        }
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : this()
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            initArmorThickness = ArmorThickness;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }

        public double ArmorThickness
        {
            get => armorThinkness;
            set => armorThinkness = value;
        }

        public double MainWeaponCaliber
        {
            get
            {
                return mainWeaponCaliber;
            }
            protected set
            {
                mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                speed = value;
            }
        }

        public ICollection<string> Targets
        {
            get
            {
                return targets.AsReadOnly();
            }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            ArmorThickness = initArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"- {Name}");
            result.AppendLine($"*Type: {this.GetType().Name}");
            result.AppendLine($"*Armor thickness: {ArmorThickness}");
            result.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            result.AppendLine($"*Speed: {Speed} knots");
            result.Append($"*Targets: ");
            if (targets.Count == 0)
            {
                result.Append($"None");
            }
            else
            {
                result.Append(string.Join(", ", targets));
            }

            return result.ToString().Trim();
        }
    }
}
