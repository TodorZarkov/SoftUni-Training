using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        Dictionary<string, Car> cars;
        int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>(capacity);
        }

        public int Count { get { return this.cars.Count; } }

        public string AddCar(Car car)
        {
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Count >= this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (!cars.ContainsKey(RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(RegistrationNumber);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string RegistrationNumber)
        {
            return cars.GetValueOrDefault(RegistrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            RegistrationNumbers.ForEach(rn => cars.Remove(rn));
        }
    }
}
