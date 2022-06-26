using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Phone_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ptrnPhones = @",\s*";
            Regex rxPhones = new Regex(ptrnPhones);
            List<string> phones = rxPhones.Split(Console.ReadLine()).ToList();
            string line = Console.ReadLine();
            string patternCmd = @"\s*-\s*|:|\s+";
            Regex rxCmd = new Regex(patternCmd);
            while (line != "End")
            {
                string[] command = rxCmd.Split(line);
                if (command[0] == "Add")
                {
                    if (!phones.Contains(command[1]))
                        phones.Add(command[1]);
                }
                else if (command[0] == "Remove")
                {
                    phones.Remove(command[1]);
                }
                else if (command[0] == "Bonus")
                {
                    int indexOf = phones.IndexOf(command[2]);
                    if (indexOf != -1)
                    {
                        if (indexOf + 1 >= phones.Count)
                        {
                            phones.Add(command[3]);
                        }
                        else
                        {
                            phones.Insert(indexOf + 1, command[3]);
                        }
                    }
                }
                else if (command[0] == "Last")
                {
                    if (phones.Remove(command[1]))
                        phones.Add(command[1]);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}

