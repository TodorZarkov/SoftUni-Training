
namespace _01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double baseFuelConsumption, double tankCapacity) : base(fuelQuantity, baseFuelConsumption, tankCapacity)
        {
            AdditionalFuelCons = 0.9;
        }

        
    }
}
