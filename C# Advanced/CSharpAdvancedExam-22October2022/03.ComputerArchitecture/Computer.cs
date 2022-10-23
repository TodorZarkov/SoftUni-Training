using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>(Capacity);
        }


        public string Model { get; }
        public int Capacity { get; }
        public List<CPU> Multiprocessor { get; }
        public int Count { get { return Multiprocessor.Count; } }



        public void Add(CPU cpu)
        {
            if (Count >= Capacity)
            {
                return;
            }
            Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            var cpu = Multiprocessor.Find(cpu => string.Equals(cpu.Brand, brand));
            return Multiprocessor.Remove(cpu);
        }

        public CPU MostPowerful()
        {

            CPU mostPowerful = Multiprocessor.OrderByDescending(cpu => cpu.Frequency).First();
            return mostPowerful;
        }
        public CPU GetCPU(string brand)
        {
            return Multiprocessor.Find(cpu => string.Equals(cpu.Brand, brand));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            if (Multiprocessor.Count != 0)
            {
                Multiprocessor.ForEach(cpu => sb.AppendLine(cpu.ToString()));
            }
            
            return sb.ToString().Trim();
        }

    }
}
