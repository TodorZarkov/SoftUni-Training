namespace NavalVessels.Models.Concretes
{
    
    using Models;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;

    public class Battleship : Vessel
    {
        bool sonarMode;

        
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }


        public bool SonarMode { get => sonarMode; private set => sonarMode = value; }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if(SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");
            return result.ToString().Trim();
        }
    }
}
