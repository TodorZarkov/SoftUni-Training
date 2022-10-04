using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            string line = Console.ReadLine();
            while (line != "exam finished")
            {
                string[] data = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                if (data[1] == "banned")
                {
                    users.Remove(name);
                }
                else
                {
                    string language = data[1];
                    int points = int.Parse(data[2]);

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;

                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, 0);
                    }
                    if (users[name] < points)
                    {
                        users[name] = points;
                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            users.OrderByDescending(u => u.Value).ThenBy(u => u.Key).ToList().ForEach(u => Console.WriteLine($"{u.Key} | {u.Value}"));

            Console.WriteLine("Submissions:");
            submissions.OrderByDescending(l => l.Value).ThenBy(l => l.Key).ToList().ForEach(s => Console.WriteLine($"{s.Key} - {s.Value}"));
        }
    }
}
