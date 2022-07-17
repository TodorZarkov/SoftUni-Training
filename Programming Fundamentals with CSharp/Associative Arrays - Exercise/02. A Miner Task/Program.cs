using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mining = new Dictionary<string, int>();
            bool isOddLine = true;
            string line = Console.ReadLine();
            string resource = string.Empty;
            int quantity = 0;
            while (line != "stop")
            {
                if (isOddLine)
                {
                    resource = line;
                    isOddLine = false;
                }
                else
                {
                    quantity = int.Parse(line);
                    if (!mining.ContainsKey(resource))
                    {
                        mining[resource] = 0;
                    }
                    mining[resource] += quantity;
                    isOddLine = true;
                }

                line = Console.ReadLine();
            }
            mining.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key} -> {kvp.Value}"));
        }
    }
}
