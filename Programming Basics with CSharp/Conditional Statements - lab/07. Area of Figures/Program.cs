using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            double arg1 = double.Parse(Console.ReadLine());

            if (figure == "square")
            {
                area = Math.Pow(arg1, 2);
            }
            else if (figure == "rectangle")
            {
                double arg2 = double.Parse(Console.ReadLine());
                area = arg1 * arg2;
            }
            else if (figure == "circle")
            {
                area = Math.PI * Math.Pow(arg1, 2);
            }
            else if (figure == "triangle")
            {
                double arg2 = double.Parse(Console.ReadLine());
                area = arg1 * arg2 / 2;
            }

            Console.WriteLine("{0:f3}",area);
        }
    }
}
