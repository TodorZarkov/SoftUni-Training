using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = personData[0] + " " + personData[1];
            string personAddres = personData[2];
            Tuple<string, string> person = new Tuple<string, string>(personName, personAddres);

            string[] beerData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> manVsBeer = new Tuple<string, int>(beerData[0], int.Parse(beerData[1]));

            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> tData = new Tuple<int, double>(int.Parse(data[0]), double.Parse(data[1]));

            Console.WriteLine(person);
            Console.WriteLine(manVsBeer);
            Console.WriteLine(tData);
        }
    }
}
