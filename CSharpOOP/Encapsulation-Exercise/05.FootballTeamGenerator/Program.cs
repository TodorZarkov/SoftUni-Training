using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string[] data = Console.ReadLine().Split(';');
            while (data[0] != "END")
            {
                try
                {
                    switch (data[0])
                    {
                        case "Team":
                            Team team = new Team(data[1]);
                            teams.Add(team.Name, team);
                            break;
                        case "Add":
                            if (!teams.ContainsKey(data[1]))
                            {
                                Console.WriteLine($"Team {data[1]} does not exist.");
                                break;
                            }
                            Player player = new Player(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                            teams[data[1]].AddPlayer(player);
                            break;
                        case "Remove":
                            teams[data[1]].RemovePlayer(data[2]);
                            break;
                        case "Rating":
                            if (!teams.ContainsKey(data[1]))
                            {
                                Console.WriteLine($"Team {data[1]} does not exist.");
                                break;
                            }
                            Console.WriteLine($"{data[1]} - {teams[data[1]].Rating}");
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                data = Console.ReadLine().Split(';');
            }
        }
    }
}
