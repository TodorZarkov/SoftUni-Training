using System;

namespace _01._1.Sort_Numbers
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

            for (int i = 0; i < toSort.Length - 1; i++)
            {
                for (int j = i + 1; j < toSort.Length; j++)
                {
                    if (toSort[j] > toSort[i])
                    {
                        double buffer = toSort[j];
                        toSort[j] = toSort[i];
                        toSort[i] = buffer;
                    }
                }
            }

            foreach (var item in toSort)
            {
                Console.WriteLine(item);
            }
        }
    }
}
