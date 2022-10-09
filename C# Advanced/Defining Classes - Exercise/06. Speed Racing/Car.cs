using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = 0;
        }

        public string Model { get;}
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get;}
        public double TraveledDistance { get; set; }

        public void Drive(double amountOfKM)
        {
            double tripFuel = amountOfKM * this.FuelConsumptionPerKilometer;
            if (this.FuelAmount >= tripFuel)
            {
                this.FuelAmount -= tripFuel;
                TraveledDistance += amountOfKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
