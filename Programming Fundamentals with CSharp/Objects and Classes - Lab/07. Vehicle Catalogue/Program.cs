using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Catalogue catalogue = new Catalogue();
            while (line != "end")
            {
                string[] vehicleData = line.Split('/').ToArray();
                //{type}/{brand}/{model}/{horse power / weight}
                if (vehicleData[0] == "Car")
                {
                    Car car = new Car(vehicleData[1], vehicleData[2], int.Parse(vehicleData[3]));
                    catalogue.Cars.Add(car);
                }
                else if (vehicleData[0] == "Truck")
                {
                    Truck truck = new Truck(vehicleData[1], vehicleData[2], int.Parse(vehicleData[3]));
                    catalogue.Trucks.Add(truck);
                }
                line = Console.ReadLine();
            }

            List<Car> orderedCars = catalogue.Cars.OrderBy(car => car.Brand).ToList();
            List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(truck => truck.Brand).ToList();

            if (orderedCars.Count != 0)
                Console.WriteLine("Cars:");
            foreach (var car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
            if (orderedTrucks.Count != 0)
                Console.WriteLine("Trucks:");
            foreach (var truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }

        }
        class Car
        {
            public Car(string brand, string model, int horsePower)
            {
                this.Brand = brand;
                this.Model = model;
                this.HorsePower = horsePower;
            }
            public string Type { get { return "Car"; } }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
        class Truck
        {
            public Truck(string brand, string model, int weight)
            {
                this.Brand = brand;
                this.Model = model;
                this.Weight = weight;
            }
            public string Type { get { return "Truck"; } }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }
        class Catalogue
        {
            public Catalogue()
            {
                this.Cars = new List<Car>();
                this.Trucks = new List<Truck>();
            }
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }
        }
    }
}
