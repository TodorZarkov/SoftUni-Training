using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personData = Console.ReadLine().Split(' ', 4, StringSplitOptions.RemoveEmptyEntries);
            string personName = personData[0] + " " + personData[1];
            string personAddres = personData[2];
            string personTown = personData[3];
            Threeuple<string, string, string> person = new Threeuple<string, string, string>(personName, personAddres, personTown);

            string[] beerData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, int, string> manVsBeer = new Threeuple<string, int, string>(beerData[0], int.Parse(beerData[1]), beerData[2]== "drunk"?"True":"False");

            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, double,string> tData = new Threeuple<string, double,string>(data[0], double.Parse(data[1]), data[2]);

            Console.WriteLine(person);
            Console.WriteLine(manVsBeer);
            Console.WriteLine(tData);
        }
    }
}
