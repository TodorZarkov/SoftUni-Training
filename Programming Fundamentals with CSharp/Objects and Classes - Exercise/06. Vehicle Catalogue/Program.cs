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

            int sum = 0;
            List<Vehicle> cars = vehicles.Where(x => x.Type == "car").ToList();
            cars.ForEach(c => sum += c.HorsePower);
            double average = (double)sum / cars.Count;
            Console.WriteLine($"Cars have average horsepower of: {average:f2}.");

            sum = 0;
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "truck").ToList();
            trucks.ForEach(t => sum += t.HorsePower);
            average = (double)sum / trucks.Count;
            Console.WriteLine($"Trucks have average horsepower of: {average:f2}.");
        }

        class Vehicle
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Colour { get; set; }
            public int HorsePower { get; set; }
            public override string ToString()
            {
                return @$"Type: {this.Type[0].ToString().ToUpper() + this.Type.Remove(0,1).ToLower()}
Model: {this.Model}
Color: {this.Colour}
Horsepower: {this.HorsePower}";
            }
        }
    }
}
