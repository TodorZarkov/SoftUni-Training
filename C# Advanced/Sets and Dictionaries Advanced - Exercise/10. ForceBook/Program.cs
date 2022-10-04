using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> users = new Dictionary<string, string>();
            Dictionary<string, HashSet<string>> sides = new Dictionary<string, HashSet<string>>();

            Regex rx = new Regex(@" \| | -> ");
            string line = Console.ReadLine();
            while (line != "Lumpawaroo")
            {
                string user = "";
                string side = "";
                bool IsUserSide = line.Contains(" -> ");
                string[] data = rx.Split(line);
                if (IsUserSide)
                {
                    user = data[0];
                    side = data[1];
                }
                else
                {
                    user = data[1];
                    side = data[0];
                }

                if (!users.ContainsKey(user))
                {
                    if (IsUserSide)
                    {
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    users.Add(user, side);
                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new HashSet<string>());
                    }
                    sides[side].Add(user);
                }
                else
                {
                    if (users[user] != side)
                    {
                        sides[users[user]].Remove(user);
                        users[user] = side;
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new HashSet<string>());
                        }
                        sides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
                line = Console.ReadLine();
            }
            sides = sides.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key).ToDictionary(key => key.Key, value => value.Value);
            foreach (var side in sides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    side.Value.OrderBy(u => u).ToList().ForEach(user => Console.WriteLine($"! {user}"));
                }
            }

        }
    }
}
