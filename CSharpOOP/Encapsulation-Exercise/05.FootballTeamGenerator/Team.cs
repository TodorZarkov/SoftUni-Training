using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        Dictionary<string,Player> players;
        string name;
        int rating;

        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string,Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                Regex empty = new Regex(@"^\s+$");
                if (value == null || value == "" || empty.IsMatch(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Rating 
        {
            get => CalculateRating();
        }
        private int NumberOfPlayers { get => players.Count; }
        private int CalculateRating()
        {
            if (NumberOfPlayers == 0) return 0;

            double avarageSkillLevel = 0;
            foreach (var player in players)
            {
                double skilLevel = (player.Value.Endurance + player.Value.Sprint + player.Value.Dribble + player.Value.Passing + player.Value.Shooting) / 5d;
                avarageSkillLevel += skilLevel;
            }
            avarageSkillLevel = avarageSkillLevel / NumberOfPlayers;

            return (int)Math.Round(avarageSkillLevel);// TO CHECK ROUNDING
        }
        public void RemovePlayer(string playerName)
        {
            if (!players.Remove(playerName))//TO CHECK ARGUMENT NULL ECXEPTON
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }
    
    }
}
