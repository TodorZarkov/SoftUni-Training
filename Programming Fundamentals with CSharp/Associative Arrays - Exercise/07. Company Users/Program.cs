using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmploees = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] companyEmpleeData = line.Split(" -> ");
                string company = companyEmpleeData[0];
                string emploeeID = companyEmpleeData[1];
                if (companyEmploees.ContainsKey(company))
                {
                    if (!companyEmploees[company].Contains(emploeeID))
                        companyEmploees[company].Add(emploeeID);
                }
                else
                {
                    companyEmploees[company] = new List<string> { emploeeID };
                }

                line = Console.ReadLine();
            }
            foreach (var kvp in companyEmploees)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (string empID in kvp.Value)
                {
                    Console.WriteLine($"-- {empID}");
                }
            }
        }
    }
}
