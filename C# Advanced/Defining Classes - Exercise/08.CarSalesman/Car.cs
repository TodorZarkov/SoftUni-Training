using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        bool isColorSet = false;
        bool isWeightSet = false;
        int weight;
        string color;
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public int Weight
        {
            get { return weight; }
            set { isWeightSet = true; weight = value; }
        }
        public string Color
        {
            get { return color; }
            set { isColorSet = true;color = value; }
        }

        public override string ToString()
        {
            string wgt = this.isWeightSet ? $"{this.Weight}" :"n/a";
            string clr = this.isColorSet ? $"{this.Color}" :"n/a";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.Append(this.Engine.ToString());
            sb.AppendLine($"  Weight: {wgt}");//optional
            sb.Append($"  Color: {clr}");//optional
            return sb.ToString();
        }
    }
}
