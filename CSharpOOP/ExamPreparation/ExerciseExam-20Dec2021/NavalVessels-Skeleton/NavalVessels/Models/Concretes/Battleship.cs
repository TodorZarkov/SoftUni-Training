namespace NavalVessels.Models.Concretes
{
    
    using Models;
    using NavalVessels.Models.Contracts;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        const double initialArmorThickness = 300;
        const double caliberChange = 40;
        const double speedChange = 5;

        
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        { 
            SonarMode = false;
        }


        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = initialArmorThickness;
        }
           
        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if(SonarMode)
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
            result.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");
            return result.ToString().TrimEnd();
        }
    }
}
