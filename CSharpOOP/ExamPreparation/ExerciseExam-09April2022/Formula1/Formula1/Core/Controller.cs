namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Utilities;

    internal class Controller : IController
    {
        PilotRepository pilotRepository;
        RaceRepository raceRepository;
        FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            IFormulaOneCar car = carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type carTypeToBe = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (carTypeToBe == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car;
            try
            {
                car = (IFormulaOneCar)Activator.CreateInstance(carTypeToBe, model, horsepower, engineDisplacement);
            }
            catch (Exception outerException)
            {

                throw outerException.InnerException;
            }

            carRepository.Add(car);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);

        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            return String.Join(Environment.NewLine, pilotRepository.Models.
                OrderByDescending(p => p.NumberOfWins).
                Select(p => p.ToString()));
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            return String.Join(Environment.NewLine, raceRepository.
                Models.
                Where(r => r.TookPlace).
                ToList().
                Select(r => r.RaceInfo()).Select(rs=>rs.Trim())).Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> finished = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            race.TookPlace = true;
            finished[0].WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {finished[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {finished[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {finished[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
