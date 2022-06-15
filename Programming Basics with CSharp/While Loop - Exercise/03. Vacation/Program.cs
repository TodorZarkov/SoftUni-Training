using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double savings = double.Parse(Console.ReadLine());
            int days = 0;
            int spendsCounter = 0;
            bool spent = true;

            while (savings < tripPrice)
            {
                string transfer = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                days++;
                switch (transfer)
                {
                    case "spend":
                        if (spent)
                            spendsCounter++;
                        else
                            spendsCounter = 1;

                        if (spendsCounter == 5)
                        {
                            Console.WriteLine($"You can't save the money.");
                            Console.WriteLine(days);
                            return;
                        }

                        if (savings < sum)
                            savings = 0;
                        else
                            savings -= sum;

                        spent = true;
                        break;
                    case "save":
                        savings += sum;
                        spent = false;
                        break;
                }
            }
            Console.WriteLine($"You saved the money for {days} days.");
        }
    }
}
