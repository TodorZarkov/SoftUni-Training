
namespace Formula1.Models
{
    using Contracts;
    using Formula1.Utilities;
    using System;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        const int minNameLength = 3;

        const int minHorsepower = 900;
        const int maxHorsepower = 1015;

        const double minDisplacement = 1.6;
        const double maxDisplacement = 2;


        string model;
        int horsepower;
        double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return horsepower;
            }
            private set
            {
                if (value < minHorsepower || value > maxHorsepower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return engineDisplacement;
            }
            private set
            {
                if (value < minDisplacement || value > maxDisplacement)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return (EngineDisplacement / Horsepower) * laps;
        }
    }
}
