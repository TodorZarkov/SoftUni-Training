using System;

namespace _01._Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(' ');
            while (commands[0] != "Abracadabra")
            {
                string command = commands[0];
                switch (command)
                {
                    case "Abjuration":
                        spell = spell.ToUpper();
                        Console.WriteLine(spell);
                        break;
                    case "Necromancy":
                        spell = spell.ToLower();
                        Console.WriteLine(spell);
                        break;
                    case "Illusion":
                        int index = int.Parse(commands[1]);
                        string letter = commands[2];
                        if (index >= spell.Length)
                        {
                            Console.WriteLine("The spell was too weak.");
                            break;
                        }
                        spell = spell.Remove(index, 1).Insert(index, letter);//to check!!!
                        Console.WriteLine("Done!");
                        break;
                    case "Divination":
                        string toReplace = commands[1];
                        string toReplaceWith = commands[2];
                        if (!spell.Contains(toReplace))
                        {
                            break;
                        }
                        spell = spell.Replace(toReplace, toReplaceWith);
                        Console.WriteLine(spell);
                        break;
                    case "Alteration":
                        string toDelete = commands[1];
                        if (!spell.Contains(toDelete))
                        {
                            break;
                        }
                        spell = spell.Replace(toDelete, "");// all occurences here are removed ???!!!
                        Console.WriteLine(spell);
                        break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }

                commands = Console.ReadLine().Split(' ');
            }
        }
    }
}
