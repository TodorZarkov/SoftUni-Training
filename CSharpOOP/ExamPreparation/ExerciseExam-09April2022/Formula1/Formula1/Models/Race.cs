namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Race : IRace
    {
        const int minRaceNameLength = 5;

        string raceName;
        int numberOfLabs;
        ICollection<IPilot> pilots;


        private Race()
        {
            TookPlace = false;
            pilots = new List<IPilot>();
        }
        public Race(string raceName, int numberOfLaps) : this()
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }



        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < minRaceNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLabs;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLabs = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return new List<IPilot>(pilots);
            }
        }



        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            result.AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");
            return result.ToString().Trim();
        }
    }
}
