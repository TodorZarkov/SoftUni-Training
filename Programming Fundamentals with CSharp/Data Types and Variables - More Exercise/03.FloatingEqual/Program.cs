using System;

namespace _03.FloatingEqual_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstToCompare = double.Parse(Console.ReadLine());
            double secondTocompare = double.Parse(Console.ReadLine());
            double epsilon = 0.000001;
            string areEqual = (Math.Abs(firstToCompare - secondTocompare) < epsilon) ? "True" : "False";
            Console.WriteLine(areEqual);



        }
    }
}
