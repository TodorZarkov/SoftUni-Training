
namespace _01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double baseFuelConsumption) : base(fuelQuantity, baseFuelConsumption)
        {
            AdditionalFuelCons = 1.6;
        }

        public override void Refuel(double liters)
        {
            double fuelToAdd = 0.95 * liters;
            FuelQuantity += fuelToAdd;
        }
    }
}
