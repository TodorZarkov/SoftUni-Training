using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> racers = new Dictionary<string, int>();
            Regex digit = new Regex(@"\d");
            Regex letter = new Regex(@"[A-Za-z]");
            string line = Console.ReadLine();
            while (line != "end of race")
            {
                string name = ParseName(letter, line);
                int distance = ParseDistance(digit, line);
                if (IsRacer(name, names))
                {
                    if (!racers.ContainsKey(name))
                    {
                        racers[name] = distance;
                    }
                    racers[name] += distance;
                }
                line = Console.ReadLine();
            }
            //racers.OrderByDescending(r => r.Value).ToList().ForEach(kvp => Console.WriteLine(kvp.Key));
            int limitPlace = 3;
            if (racers.Count < 3 )
            {
                limitPlace = racers.Count;
            }
            int place = 1;
            foreach (var item in racers.OrderByDescending(r => r.Value))
            {
                if (place <= limitPlace)
                    Console.WriteLine($"{place}{Ordinal(place)} place: {item.Key}");
                else
                    break;
                place++;
            }
        }
        static bool IsRacer(string name, List<string> names)
        {
            foreach (string item in names)
            {
                if (item == name)
                {
                    return true;
                }
            }
            return false;
        }

        static string ParseName(Regex rx, string line)
        {
            StringBuilder name = new StringBuilder();
            MatchCollection letters = rx.Matches(line);
            foreach (Match match in letters)
            {
                name.Append(match.Value);
            }
            return name.ToString();
        }
        static int ParseDistance(Regex rx, string line)
        {
            MatchCollection digits = rx.Matches(line);
            int distance = 0;
            foreach (Match match in digits)
            {
                distance += int.Parse(match.Value);
            }
            return distance;
        }
        static string Ordinal(int number)
        {
            if (number == 1)
            {
                return "st";
            }
            else if (number == 2)
            {
                return "nd";
            }
            else if (number == 3)
            {
                return "rd";
            }
            else
            {
                return "";
            }
        }
    }
}
