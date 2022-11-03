using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        const int minStat = 0;   //TO CHECK IS IT ICLUDING?
        const int maxStat = 100; //TO CHECK IS IT ICLUDING?

        string name;
        int endurance;
        int sprint;
        int dribble;
        int passing;
        int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance { get => endurance; private set { endurance = ValidateStats(value, "Endurance"); } }
        public int Sprint { get => sprint;       private set { sprint =    ValidateStats(value,"Sprint"); } }
        public int Dribble { get => dribble;     private set { dribble =   ValidateStats(value,"Dribble"); } }
        public int Passing { get => passing;     private set { passing =   ValidateStats(value,"Passing"); } }
        public int Shooting { get => shooting;   private set { shooting =  ValidateStats(value,"Shooting"); } }

        private int ValidateStats(int value, string statName)
        {
            if (value<minStat || value>maxStat)
            {
                throw new ArgumentException($"{statName} should be between {minStat} and {maxStat}.");
            }
            return value;
        }
    }
}
