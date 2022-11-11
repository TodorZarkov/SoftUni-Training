
namespace _01.Vehicles
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = null;
            Vehicle truck = null;
            Vehicle bus = null;
            for (int i = 0; i < 3; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (data[0] == "Car")
                        car = new Car(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));

                    if (data[0] == "Truck")
                        truck = new Truck(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));

                    if (data[0] == "Bus")
                        bus = new Bus(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }


            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (data[0] == "Drive" && data[1] == "Car")
                        Console.WriteLine(car.Drive(double.Parse(data[2])));

                    if (data[0] == "Drive" && data[1] == "Truck")
                        Console.WriteLine(truck.Drive(double.Parse(data[2])));

                    if (data[0] == "Refuel" && data[1] == "Car")
                        car.Refuel(double.Parse(data[2]));

                    if (data[0] == "Refuel" && data[1] == "Truck")
                        truck.Refuel(double.Parse(data[2]));
                    

                    if(data[0] == "DriveEmpty")
                    {
                        data[0] = "Drive";
                        ((Bus)bus).IsEmpty = true;
                    }

                    if (data[0] == "Drive" && data[1] == "Bus")
                        Console.WriteLine(bus.Drive(double.Parse(data[2])));

                    if (data[0] == "Refuel" && data[1] == "Bus")
                        bus.Refuel(double.Parse(data[2]));
                    ((Bus)bus).IsEmpty = false;
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
