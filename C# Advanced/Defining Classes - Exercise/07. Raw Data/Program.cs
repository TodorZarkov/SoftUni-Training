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
                List<Car> fragileLoadedCars = cars.FindAll(car =>
                {
                    if (car.Cargo.Type == "fragile")
                    {
                        foreach (var tyre in car.Tyres)
                        {
                            if (tyre.Preasure < 1)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }).ToList();

                fragileLoadedCars.ForEach(car => Console.WriteLine(car.Model));
            }
            else if (command == "flammable")
            {
                List<Car> flammableLoadedCars = cars.FindAll(car =>
                {
                    if (car.Cargo.Type == "flammable")
                    {
                        if (car.Engine.Power > 250)
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();
                flammableLoadedCars.ForEach(car => Console.WriteLine(car.Model));
            }
        }
    }
}
