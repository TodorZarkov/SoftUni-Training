using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            int countEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countEngines; i++)
            {
                string[] engData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine();
                engine.Model = engData[0];
                engine.Power = int.Parse(engData[1]);
                if (engData.Length >= 3)
                {
                    if (int.TryParse(engData[2],out int displ))
                    {
                        engine.Displacement = displ;
                    }
                    else
                    {
                        engine.Efficiency = engData[2];
                    }
                }
                if (engData.Length == 4)
                {
                    engine.Efficiency = engData[3];
                }
                engines.Add(engine.Model, engine);
            }

            List<Car> cars = new List<Car>();
            int countCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < countCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();
                car.Model = carData[0];
                car.Engine = engines[carData[1]];
                if (carData.Length >= 3)
                {
                    if (int.TryParse(carData[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }
                if (carData.Length == 4)
                {
                    car.Color = carData[3];
                }
                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);

        }
    }
}
