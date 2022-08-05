using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> attackedPlanets = new List<string>();
        List<string> destroiedPlanets = new List<string>();
        int countOfLines = int.Parse(Console.ReadLine());
        for (int j = 0; j < countOfLines; j++)
        {




            string line = Console.ReadLine();
            Regex filterStar = new Regex(@"[starSTAR]");
            int starCount = filterStar.Matches(line).Count;
            StringBuilder decriptedLine = new StringBuilder(line);
            for (int i = 0; i < decriptedLine.Length; i++)
            {
                decriptedLine[i] = (char)((int)decriptedLine[i] - starCount);
            }

            Regex inputValidator = new Regex(@"(?<name>@[a-z,A-Z]+)([^@\-!:>]*)(?<population>:[0-9]+)([^@\-!:>]*)(?<attacType>![AD]!)([^@\-!:>]*)(?<soldierCount>->[0-9]+)");

            Match attackData = inputValidator.Match(decriptedLine.ToString());
            if (!attackData.Success)
                continue;

            string planetName = attackData.Groups["name"].Value.TrimStart('@');
            int planetPopulation = int.Parse(attackData.Groups["population"].Value.TrimStart(':'));
            string attacType = attackData.Groups["attacType"].Value.Trim('!');
            int soldierCount = int.Parse(attackData.Groups["soldierCount"].Value.TrimStart('-').TrimStart('>'));

            if (attacType == "A")
            {
                attackedPlanets.Add(planetName);
            }
            else if (attacType == "D")
            {
                destroiedPlanets.Add(planetName);
            }
            //System.Console.WriteLine($"{planetName}, {planetPopulation}, {attacType}, {soldierCount}");
        }
        Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
        attackedPlanets.Sort();
        attackedPlanets.ForEach(p => Console.WriteLine($"-> {p}"));
        Console.WriteLine($"Destroyed planets: {destroiedPlanets.Count}");
        destroiedPlanets.Sort();
        destroiedPlanets.ForEach(p => Console.WriteLine($"-> {p}"));
    }
}