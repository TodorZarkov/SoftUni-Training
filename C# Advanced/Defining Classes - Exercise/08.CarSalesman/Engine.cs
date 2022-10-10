using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        bool isDisplacemetSet = false;
        bool isEfficiencySet = false;
        int displacement;
        string efficiency;
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement
        {
            get { return displacement; }
            set { isDisplacemetSet = true; displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { isEfficiencySet = true; efficiency = value; }
        }

        public override string ToString()
        {
            string disp = isDisplacemetSet ? $"{this.Displacement}" : "n/a";
            string eff = isEfficiencySet ? $"{this.Efficiency}" : "n/a";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {disp}");//optional
            sb.AppendLine($"    Efficiency: {eff}");//optional


            return sb.ToString();
        }
    }
}
