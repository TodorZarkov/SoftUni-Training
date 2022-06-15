using System;

namespace _01._2.Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenToSort = 3;
            double[] toSort = new double[lenToSort];
            for (int i = 0; i < lenToSort; i++)
            {
                toSort[i] = double.Parse(Console.ReadLine());
            }

            Array.Sort(toSort);
            Array.Reverse(toSort);

            foreach (var item in toSort)
            {
                Console.WriteLine(item);
            }
        }
    }
}
