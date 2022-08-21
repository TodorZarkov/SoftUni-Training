using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex toMatchEggs = new Regex(@"[@#]+(?<colour>[a-z]{3,})[@#]+[^a-zA-Z0-9]*\/+(?<quantity>[0-9]+)\/+");
            string hiddenEggs = Console.ReadLine();
            MatchCollection eggsData = toMatchEggs.Matches(hiddenEggs);
            foreach (Match match in eggsData)
            {
                string colour = match.Groups["colour"].Value;
                int quantity = int.Parse(match.Groups["quantity"].Value);
                Console.WriteLine($"You found {quantity} {colour} eggs!");
            }
        }
    }
}
