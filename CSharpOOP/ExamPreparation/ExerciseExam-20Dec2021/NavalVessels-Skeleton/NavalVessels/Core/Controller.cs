namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models.Concretes;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Controller : IController
    {
        VesselRepository vessels;
        List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.Find(c => c.FullName == selectedCaptainName);
            if(captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            if (attackingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if(attackingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.Find(c => c.FullName == captainFullName);
            //if (captain == null)
            //{
            //    return String.Format(OutputMessages.CaptainNotFound, captainFullName);
            //}
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.FirstOrDefault(c => c.FullName == fullName) != null)
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == vesselType);

            if (type == null)
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel vessel;
            try
            {
                vessel = (IVessel)Activator.CreateInstance(type, name, mainWeaponCaliber, speed);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, type.Name, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            //if (vessel == null)
            //{
            //    return String.Format(OutputMessages.VesselNotFound, vesselName);
            //}

            if(vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel.GetType().Name == "Submarine")
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            //if (vessel == null)
            //{
            //    return String.Format(OutputMessages.VesselNotFound, vesselName);
            //}

            return vessel.ToString();
        }
    }
}
