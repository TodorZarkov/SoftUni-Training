namespace NavalVessels.Models.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel
    {

        bool submergeMode;


        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode = false;
        }


        public bool SubmergeMode { get => submergeMode; private set => submergeMode = value; }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");
            return result.ToString().Trim();
        }
    }
}
