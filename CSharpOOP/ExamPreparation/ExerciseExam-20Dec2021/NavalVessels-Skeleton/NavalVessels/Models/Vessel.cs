
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;

        private ICaptain captain;


        private Vessel()
        {
            Targets = new List<string>();
        }
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : this()
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                    //throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set => captain = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }
         
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            string targets = Targets.Any() ? String.Join(", ", Targets) : "None";

            StringBuilder result = new StringBuilder();
            result.AppendLine($"- {Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Armor thickness: {ArmorThickness}");
            result.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            result.AppendLine($" *Speed: {Speed} knots");
            result.AppendLine($" *Targets: {targets}");
            

            return result.ToString().TrimEnd();
        }
    }
}
