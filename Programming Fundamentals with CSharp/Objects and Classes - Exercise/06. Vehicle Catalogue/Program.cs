using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] inputData = line.Split(' ');
                string type = inputData[0];
                string model = inputData[1];
                string colour = inputData[2];
                int horsePower = int.Parse(inputData[3]);
                Vehicle vehicle = new Vehicle { Type = type, Model = model, Colour = colour, HorsePower = horsePower };
                vehicles.Add(vehicle);

                line = Console.ReadLine();
            }

            List<string> modelsToPrint = new List<string>();
            line = Console.ReadLine();
            while (line != "Close the Catalogue")
            {
                modelsToPrint.Add(line);
                line = Console.ReadLine();
            }

            modelsToPrint.ForEach(m => vehicles.Where(v => v.Model == m).ToList().ForEach(x => Console.WriteLine(x)));

            List<Vehicle> cars = vehicles.Where(x => x.Type == "car").ToList();
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "truck").ToList();

            double carsAvHorsPower = cars.Count > 0 ? cars.Average(x => x.HorsePower) : 0.00;
            double trucksAvHorsPower = trucks.Count > 0 ? trucks.Average(y => y.HorsePower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAvHorsPower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvHorsPower:f2}.");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int HorsePower { get; set; }
        public override string ToString()
        {
            return @$"Type: {this.Type[0].ToString().ToUpper() + this.Type.Remove(0, 1).ToLower()}
Model: {this.Model}
Color: {this.Colour}
Horsepower: {this.HorsePower}";
        }
    }
}

