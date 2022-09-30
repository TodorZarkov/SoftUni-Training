using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dims[0];
            int cols = dims[1];
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int sub = 3;
            int[,] temp = new int[sub, sub];
            int[,] result = new int[sub, sub];

            int sumResult = int.MinValue;
            for (int i = 0; i < rows - sub+1; i++)
            {
                for (int j = 0; j < cols - sub+1; j++)
                {
                    int tempSum = 0;
                    for (int k = i; k < i+sub; k++)
                    {
                        for (int l = j; l < j+sub; l++)
                        {
                            tempSum += matrix[k][l];
                            temp[k-i, l-j] = matrix[k][l];
                        }
                    }
                    if (tempSum > sumResult)
                    {
                        sumResult = tempSum;
                        for (int q = 0; q < sub; q++)
                        {
                            for (int p = 0; p < sub; p++)
                            {
                                result[q, p] = temp[q,p];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {sumResult}");
            for (int i = 0; i < sub; i++)
            {
                string line = "";
                for (int j = 0; j < sub; j++)
                {
                    line += $"{result[i, j]} ";
                }
                line.Trim();
                Console.WriteLine(line);
            }
        }
    }
}
