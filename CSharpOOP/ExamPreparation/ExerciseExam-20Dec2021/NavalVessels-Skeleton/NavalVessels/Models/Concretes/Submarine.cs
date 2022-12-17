namespace NavalVessels.Models.Concretes
{
    using NavalVessels.Models.Contracts;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        const double initialArmorThickness = 200;
        const double caliberChange = 40;
        const double speedChange = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            SubmergeMode = false;
        }


        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = initialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += caliberChange;
                Speed -= speedChange;
            }
            else
            {
                MainWeaponCaliber -= caliberChange;
                Speed += speedChange;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");
            return result.ToString().TrimEnd();
        }
    }
}
