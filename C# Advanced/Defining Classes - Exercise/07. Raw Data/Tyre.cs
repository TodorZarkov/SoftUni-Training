using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tyre
    {
        public Tyre(int age, double preasure)
        {
            Age = age;
            Preasure = preasure;
        }

        public int Age { get; set; }
        public double Preasure { get; set; }
    }
}
