using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contPasses = new Dictionary<string, string>();
            string line = Console.ReadLine();
            while (line != "end of contests")
            {
                string[] contPass = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string cont = contPass[0];
                string pass = contPass[1];
                contPasses.Add(cont, pass);

                line = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            line = Console.ReadLine();
            while (line != "end of submissions")
            {
                string[] data = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string password = data[1];
                string user = data[2];
                int points = int.Parse(data[3]);

                if (contPasses.ContainsKey(contest))
                {
                    if (contPasses[contest] == password)
                    {
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, new Dictionary<string, int>());
                            users[user].Add("totalPoints", 0);
                        }
                        if (!users[user].ContainsKey(contest))
                        {
                            users[user].Add(contest, 0);
                        }
                        if (users[user][contest] < points)
                        {
                            users[user]["totalPoints"] -= users[user][contest];
                            users[user][contest] = points;
                            users[user]["totalPoints"] += points;
                        }
                        
                    }
                }
                line = Console.ReadLine();
            }

            var bestUser = users.OrderByDescending(x => x.Value["totalPoints"]).Take(1);
            Console.WriteLine($"Best candidate is {bestUser.First().Key} with total {bestUser.First().Value["totalPoints"]} points.");
            Console.WriteLine("Ranking:");
            users = users.OrderBy(u => u.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");
                var contests = user.Value.OrderByDescending(cont => cont.Value).TakeLast(user.Value.Count - 1);
                foreach (var contest in contests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
