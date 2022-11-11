
namespace _01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Bus : Vehicle
    {
        private bool isEmpty;

        public Bus(double fuelQuantity, double baseFuelConsumption, double tankCapacity) : base(fuelQuantity, baseFuelConsumption, tankCapacity)
        {
            AdditionalFuelCons = 1.4;
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (value)
                {
                    AdditionalFuelCons = 0;
                }
                else
                {
                    AdditionalFuelCons = 1.4;
                }
            }
        }

    }
}
