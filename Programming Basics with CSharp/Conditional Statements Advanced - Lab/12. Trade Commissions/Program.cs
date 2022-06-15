using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double com = 0;

            if (sales < 0)
            {
                Console.WriteLine("error");
            }
            else if (sales >= 0 && sales <= 500)
            {
                switch (town)
                {
                    case "Sofia":
                        com = 0.05;
                        break;
                    case "Varna":
                        com = 0.045;
                        break;
                    case "Plovdiv":
                        com = 0.055;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                switch (town)
                {
                    case "Sofia":
                        com = 0.07;
                        break;
                    case "Varna":
                        com = 0.075;
                        break;
                    case "Plovdiv":
                        com = 0.08;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                switch (town)
                {
                    case "Sofia":
                        com = 0.08;
                        break;
                    case "Varna":
                        com = 0.10;
                        break;
                    case "Plovdiv":
                        com = 0.12;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (sales > 10000)
            {
                switch (town)
                {
                    case "Sofia":
                        com = 0.12;
                        break;
                    case "Varna":
                        com = 0.13;
                        break;
                    case "Plovdiv":
                        com = 0.145;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            if (com != 0)
            {
                Console.WriteLine($"{sales * com:f2}");
            }
        }
    }
}
