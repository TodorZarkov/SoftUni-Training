namespace NavalVessels.Models.Concretes
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Captain : ICaptain
    {
        string fullName;
        int combatExperience;
        List<IVessel> vessels;

        private Captain()
        {
            combatExperience = 0;
            vessels = new List<IVessel>();
        }
        public Captain(string fullName) : this()
        {
            FullName = fullName;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get
            {
                return combatExperience;
            }
            private set
            {
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => vessels.AsReadOnly();



        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            result.AppendLine(String.Join(Environment.NewLine, vessels.Select(v => v.ToString())));
            return result.ToString().Trim();
        }
    }
}
