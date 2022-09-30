using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            int firstSum = 0;
            int secondSum = 0;
            for (int i = 0; i < size; i++)
            {
                firstSum += matrix[i][i];
                secondSum += matrix[i][size - i - 1];
            }
            Console.WriteLine(Math.Abs(firstSum - secondSum));

        }
    }
}
