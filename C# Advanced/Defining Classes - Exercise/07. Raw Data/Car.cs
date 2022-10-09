using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Car
    {
        public Car(string model, int engineSpeed,int enginePower, string cargoType, int cargoWeight, Tyre[] tyres)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tyres = tyres;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }
    }
}
