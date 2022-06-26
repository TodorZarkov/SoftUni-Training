using System;


namespace _02._Tax_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split(">>");
            double totalTax = 0;
            foreach (string vehicle in vehicles)
            {
                string[] vehData = vehicle.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (vehData[0] != "family" && vehData[0] != "heavyDuty" && vehData[0] != "sports")
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }

                double totalCarTax = 0;
                if (vehData[0] == "family")
                {
                    totalCarTax = 50 - 5 * int.Parse(vehData[1]) + 12 * (int.Parse(vehData[2]) / 3000);
                    Console.WriteLine($"A {vehData[0]} car will pay {totalCarTax:f2} euros in taxes.");
                }
                else if (vehData[0] == "heavyDuty")
                {
                    totalCarTax = 80  - 8 * int.Parse(vehData[1]) + 14 * (int.Parse(vehData[2]) / 9000);
                    Console.WriteLine($"A {vehData[0]} car will pay {totalCarTax:f2} euros in taxes.");
                }
                else if (vehData[0] == "sports")
                {
                    totalCarTax = 100 - 9 * int.Parse(vehData[1]) + 18 * (int.Parse(vehData[2]) / 2000);
                    Console.WriteLine($"A {vehData[0]} car will pay {totalCarTax:f2} euros in taxes.");
                }

                totalTax += totalCarTax;

            }
            Console.WriteLine($"The National Revenue Agency will collect {totalTax:f2} euros in taxes.");
        }
        
    }
}
