using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                // ◦ Register: "register {username} {licensePlateNumber}"
                //◦ Unregister: "unregister {username}"
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "register")
                {
                    if (!parkingRegister.ContainsKey(command[1]))
                    {
                        parkingRegister[command[1]] = command[2];
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (!parkingRegister.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else
                    {
                        parkingRegister.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                }
            }

            parkingRegister.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key} => {kvp.Value}"));
        }
    }
}
