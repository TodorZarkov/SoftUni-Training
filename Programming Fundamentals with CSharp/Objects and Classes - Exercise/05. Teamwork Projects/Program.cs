using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            Team team = new Team("bla", "blaa");
        }
    }

    class Team
    {
        //to check for existing creator and existing team
        
        public Team(string name, string teamCreator)
        {
            this.Name = name;
            this.Creator = teamCreator;
            this.Members = new List<string>();
        }
        public string Name { get; }
        public string Creator { get; }
        public List<string> Members { get; set; }

    }
}
