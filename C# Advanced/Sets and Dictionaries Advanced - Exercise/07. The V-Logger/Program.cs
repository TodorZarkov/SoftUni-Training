using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vlogers = new Dictionary<string, List<string>>();
            string commandLine = Console.ReadLine();
            while (commandLine != "Statistics")
            {
                string[] commandData = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);
                string command = commandData[1];
                switch (command)
                {
                    case "joined":
                        string name = commandData[0];
                        if (!vlogers.ContainsKey(name))
                        {
                            vlogers.Add(name, new List<string>());
                            vlogers[name].Add("0");
                        }
                        break;
                    case "followed":
                        string firstName = commandData[0];
                        string secondName = commandData[2];
                        if (vlogers.ContainsKey(firstName) && vlogers.ContainsKey(secondName))
                        {

                        }
                        break;

                }
            }
        }
    }
}
