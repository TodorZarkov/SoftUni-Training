using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> entities = new List<IBirthable>();

            string[] line = Console.ReadLine().Split(' ');
            while (line[0] != "End")
            {
                string entityType = line[0];
                switch (entityType)
                {
                    case "Citizen":
                        Citizen citizen = new Citizen(line[1], int.Parse(line[2]), line[3], line[4]);
                        entities.Add(citizen);
                        break;
                    case "Pet":
                        Pet pet = new Pet(line[1], line[2]);
                        entities.Add(pet);
                        break;

                    default:
                        break;
                }
                line = Console.ReadLine().Split(' ');
            }

            string birth = Console.ReadLine();
            entities.Where(e => e.Birthdate.EndsWith(birth)).ToList().ForEach(e=>Console.WriteLine(e.Birthdate));
        }
    }
}
