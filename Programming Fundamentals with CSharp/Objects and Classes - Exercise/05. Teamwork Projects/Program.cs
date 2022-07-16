using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numOfTeams = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();
        for (int i = 0; i < numOfTeams; i++)
        {
            //input: {userName}-{teamName}
            string[] input = Console.ReadLine().Split('-').ToArray();
            bool isCreatorPresent = false;
            bool isTeamPresent = false;
            foreach (Team t in teams)
            {
                if (t.Name == input[1])
                {
                    System.Console.WriteLine($"Team {t.Name} was already created!");
                    isTeamPresent = true;
                    break;
                }
                if (t.Creator == input[0])
                {
                    System.Console.WriteLine($"{t.Creator} cannot create another team!");
                    isCreatorPresent = true;
                    break;
                }
            }
            if (!isTeamPresent && !isCreatorPresent)
            {
                Team team = new Team(input[1], input[0]);
                teams.Add(team);
                System.Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
            }
        }

        string line = Console.ReadLine();
        while (line != "end of assignment")
        {
            ////input: {userName}->{teamName}
            string[] assingments = line.Split("->");
            bool teamExists = false;
            //teams.Find(t)
            foreach (Team t in teams)
            {
                if (t.Name == assingments[1])
                {
                    t.Users.Add(assingments[0]);
                    teamExists = true;
                    break;
                }
            }
            if (!teamExists)
            {
                System.Console.WriteLine($"Team {assingments[1]} does not exist!");
            }

            line = Console.ReadLine();
        }

    }

}

class Team
{
    //check for dublicat name and creator - outside.
    //non existing team check - outside
    //member of a team cannot join another team check - outside
    public Team(string name, string creator)
    {
        this.Name = name;
        this.Creator = creator;
        this.Users = new List<string>();
    }
    public string Name { get; }
    public string Creator { get; }
    public List<string> Users { get; set; }
}