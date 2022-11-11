
namespace _01.Vehicles
{
    using System;
    public abstract class Vehicle : ExceptionMessage
    {
        private double fuelQuantity;
        private double baseFuelConsumption;

        private double additionalFuelCons;



        public Vehicle(double fuelQuantity, double baseFuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            BaseFuelConsumption = baseFuelConsumption;
        }


        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(CannotBeEmpty, nameof(FuelQuantity)));
                }
                fuelQuantity = value;
            }
        }


        public double BaseFuelConsumption
        {
            get { return baseFuelConsumption; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(CannotBeEmpty, nameof(BaseFuelConsumption)));
                }
                baseFuelConsumption = value;
            }
        }


        public double AdditionalFuelCons
        {
            get { return additionalFuelCons; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(CannotBeEmpty, nameof(AdditionalFuelCons)));
                }
                additionalFuelCons = value;
            }
        }



        public virtual string Drive(double kilometers)
        {
            double fuelToDecrese = kilometers * (BaseFuelConsumption + AdditionalFuelCons);


            if (FuelQuantity - fuelToDecrese < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }


            FuelQuantity -= fuelToDecrese;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }


        public abstract void Refuel(double liters);


        public override string ToString()
        {
            return $"{this.GetType().Name}: {Math.Round(fuelQuantity, 2,MidpointRounding.AwayFromZero):f2}";
        }
    }
}
