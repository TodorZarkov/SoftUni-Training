
namespace _01.Vehicles
{
    using System;
    public abstract class Vehicle : ExceptionMessage
    {
        private double fuelQuantity;
        private double baseFuelConsumption;
        private double tankCapacity;

        private double additionalFuelCons;



        public Vehicle(double fuelQuantity, double baseFuelConsumption, double tankCapacity)
        {

            FuelQuantity = fuelQuantity;
            BaseFuelConsumption = baseFuelConsumption;
            TankCapacity = tankCapacity;
            if(FuelQuantity>TankCapacity)
            {
                FuelQuantity = 0;
            }
        }


        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MustBePositive, "Fuel"));
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
                    throw new ArgumentException(string.Format(MustBePositive, nameof(BaseFuelConsumption)));
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
                    throw new ArgumentException(string.Format(MustBePositive, nameof(AdditionalFuelCons)));
                }
                additionalFuelCons = value;
            }
        }

        public double TankCapacity { get => tankCapacity; private set => tankCapacity = value; }



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



        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(String.Format(MustBePositive, "Fuel"));
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException(string.Format(CannotFitFuelInTheTank, liters));
            }
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Math.Round(fuelQuantity, 2,MidpointRounding.AwayFromZero):f2}";
        }
    }
}
