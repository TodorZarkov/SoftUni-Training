
namespace _01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double baseFuelConsumption, double tankCapacity) : base(fuelQuantity, baseFuelConsumption, tankCapacity)
        {
            AdditionalFuelCons = 1.6;
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(String.Format(MustBePositive, "Fuel"));
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException(string.Format(CannotFitFuelInTheTank, liters));
            }


            double fuelToAdd = 0.95 * liters;
            FuelQuantity += fuelToAdd;
        }
    }
}
