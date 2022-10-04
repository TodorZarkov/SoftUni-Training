using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vlogers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> vlogersFowols = new Dictionary<string, int>();

            string commandLine = Console.ReadLine();
            while (commandLine != "Statistics")
            {
                string[] commandData = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandData[1];
                switch (command)
                {
                    case "joined":
                        string name = commandData[0];
                        if (!vlogers.ContainsKey(name))
                        {
                            vlogers.Add(name, new HashSet<string>());
                            vlogersFowols.Add(name, 0);
                        }
                        break;
                    case "followed":
                        string firstName = commandData[0];
                        string secondName = commandData[2];
                        if (vlogers.ContainsKey(firstName) && vlogers.ContainsKey(secondName))
                        {
                            if (!(firstName == secondName) && !vlogers[secondName].Contains(firstName))
                            {
                                vlogers[secondName].Add(firstName);
                                vlogersFowols[firstName]++;
                            }
                        }
                        break;
                }
                commandLine = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            var ordVlogers = vlogers.OrderByDescending(v => v.Value.Count).ThenBy(v => vlogersFowols[v.Key]).ToList();

            Console.WriteLine($"1. {ordVlogers[0].Key} : {ordVlogers[0].Value.Count} followers, {vlogersFowols[ordVlogers[0].Key]} following");
            if (ordVlogers[0].Value.Count != 0)
            {
                ordVlogers[0].Value.OrderBy(follower => follower).ToList().ForEach(follower =>
                {
                    Console.WriteLine($"*  {follower}");
                });

            }

            for (int i = 1; i < vlogers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ordVlogers[i].Key} : {ordVlogers[i].Value.Count} followers, {vlogersFowols[ordVlogers[i].Key]} following");
            }
        }
    }
}
