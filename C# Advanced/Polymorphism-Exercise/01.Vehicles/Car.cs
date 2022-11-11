
namespace _01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double baseFuelConsumption) : base(fuelQuantity, baseFuelConsumption)
        {
            AdditionalFuelCons = 0.9;
        }

        

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
