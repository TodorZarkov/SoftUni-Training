namespace NavalVessels.Models.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Captain : ICaptain
    {
        const int increaseCombatExperience = 10;
        string fullName;

        private Captain() 
        {
            CombatExperience = 0;
            Vessels = new HashSet<IVessel>();
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
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }



        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += increaseCombatExperience;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            foreach (IVessel vessel in Vessels)
            {
                result.AppendLine(vessel.ToString());
            }
            return result.ToString().TrimEnd();

        }
    }
}
