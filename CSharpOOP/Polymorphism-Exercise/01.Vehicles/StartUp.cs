
namespace _01.Vehicles
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = null;
            Vehicle truck = null;
            for (int i = 0; i < 2; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Car")
                    car = new Car(double.Parse(data[1]), double.Parse(data[2]));

                if (data[0] == "Truck")
                    truck = new Truck(double.Parse(data[1]), double.Parse(data[2]));
            }


            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Drive" && data[1] == "Car")
                    Console.WriteLine(car.Drive(double.Parse(data[2])));

                if (data[0] == "Drive" && data[1] == "Truck")
                    Console.WriteLine(truck.Drive(double.Parse(data[2])));

                if (data[0] == "Refuel" && data[1] == "Car")
                    car.Refuel(double.Parse(data[2]));

                if (data[0] == "Refuel" && data[1] == "Truck")
                    truck.Refuel(double.Parse(data[2]));
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
