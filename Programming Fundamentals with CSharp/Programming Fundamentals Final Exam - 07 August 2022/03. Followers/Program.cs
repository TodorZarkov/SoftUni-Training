using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();
            string[] commands = Console.ReadLine().Split(": ");
            while (commands[0] != "Log out")
            {
                string command = commands[0];
                string name = commands[1];
                switch (command)
                {
                    case "New follower":
                        if (followers.ContainsKey(name))
                        {
                            break;
                        }
                        followers[name] = new int[2];//is 0?? to check!!
                        break;
                    case "Like":
                        int countOfLikes = int.Parse(commands[2]);
                        if (!followers.ContainsKey(name))
                        {
                            followers[name] = new int[2];//is 0 after init??? to check!
                        }
                        followers[name][0] += countOfLikes;//the zero index is likes;
                        break;
                    case "Comment":
                        if (!followers.ContainsKey(name))
                        {
                            followers[name] = new int[2];
                        }
                        followers[name][1]++;//the one index is comments.
                        break;
                    case "Blocked":
                        if (!followers.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} doesn't exist.");
                            break;
                        }
                        followers.Remove(name);
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine().Split(": ");
            }
            Console.WriteLine($"{followers.Count} followers");
            followers.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value[0] + kvp.Value[1]}"));
        }
    }
}
