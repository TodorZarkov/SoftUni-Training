using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                if (data.Length == 4)
                {
                    Citizen citizen = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                    buyers.Add(citizen.Name,citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(data[0], int.Parse(data[1]), data[2]);
                    buyers.Add(rebel.Name, rebel);
                }
            }


            string name = Console.ReadLine();
            while (name != "End")
            {
                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
                name = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(kvp => kvp.Value.Food)); 

















            //List<IBirthable> entities = new List<IBirthable>();

            //string[] line = Console.ReadLine().Split(' ');


            //while (line[0] != "End")
            //{
            //    string entityType = line[0];
            //    switch (entityType)
            //    {
            //        case "Citizen":
            //            Citizen citizen = new Citizen(line[1], int.Parse(line[2]), line[3], line[4]);
            //            entities.Add(citizen);
            //            break;
            //        case "Pet":
            //            Pet pet = new Pet(line[1], line[2]);
            //            entities.Add(pet);
            //            break;

            //        default:
            //            break;
            //    }
            //    line = Console.ReadLine().Split(' ');
            //}

            //string birth = Console.ReadLine();
            //entities.Where(e => e.Birthdate.EndsWith(birth)).ToList().ForEach(e => Console.WriteLine(e.Birthdate));
        }
    }
}
