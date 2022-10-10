using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                Engine engine = new Engine(int.Parse(carData[1]), int.Parse(carData[2]));
                Cargo cargo = new Cargo(carData[4], int.Parse(carData[3]));
                Tyre[] tyres = new Tyre[4];

                int indexTyres = 0;
                for (int j = 5; j < 12; j = j + 2)
                {
                    tyres[indexTyres] = new Tyre(int.Parse(carData[j + 1]), double.Parse(carData[j]));
                    indexTyres++;
                }

                Car car = new Car(model, engine, cargo, tyres);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars.Where(car => car.Cargo.Type == "fragile" && car.Tyres.Any(t => t.Preasure < 1)).Select(car => car.Model).ToList().ForEach(car => Console.WriteLine(car));
            }
            else if (command == "flammable")
            {
                cars.Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250).Select(car => car.Model).ToList().ForEach(car => Console.WriteLine(car));
            }
        }
    }
}
