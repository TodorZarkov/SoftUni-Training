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

        }
    }

    class Team
    {
        Team(string name, string teamCreator)
        {
            this.Name = name;
            this.Creator = teamCreator;
            List<string> members = new List<string>();
            this.Members = members;
        }
        public string Name { get; }
        public string Creator { get; }
        public List<string> Members { get; set; }

    }
}
