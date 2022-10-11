using System;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(double.Parse(line));
            }

            string toMatch = Console.ReadLine();
            Console.WriteLine(box.Count(box.Items, double.Parse(toMatch)));
        }
    }
}
