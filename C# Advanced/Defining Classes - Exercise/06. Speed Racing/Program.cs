using System;
using System.Collections.Generic;

namespace _06._Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,Car> cars = new Dictionary<string,Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] dataCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(dataCar[0], double.Parse(dataCar[1]), double.Parse(dataCar[2]));
                cars.Add(car.Model,car);
            }
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] commands = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commands[1];
                double distance = double.Parse(commands[2]);
                Car car = cars[model];
                car.Drive(distance);
                line = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TraveledDistance}");
            }

        }
    }
}
