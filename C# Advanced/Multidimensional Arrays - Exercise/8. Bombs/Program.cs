using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] field = Init();
            Queue<string> bombs = new Queue<string>();
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(b => bombs.Enqueue(b));

            while (bombs.Count > 0)
            {
                int[] bomb = bombs.Dequeue().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int bRow = bomb[0];
                int bCol = bomb[1];

                Explode(bRow, bCol, field);
            }

            Console.WriteLine($"Alive cells: {GetAliveCount(field)}");

            Console.WriteLine($"Sum: {GetAliveSum(field)}");

            Print(field);
        }


        static void Explode(int bRow, int bCol, int[,] field)
        {
            int magnitude = field[bRow, bCol];
            if (magnitude <= 0)
                return;
            field[bRow, bCol] = 0;

            int[,] valid = ValidRanges(bRow, bCol, field.GetLength(0));
            for (int k = 0; k < valid.GetLength(0); k++)
            {
                int validRow = valid[k, 0];
                int validCol = valid[k, 1];
                if (field[validRow, validCol] > 0)
                    field[validRow, validCol] -= magnitude;
            }

        }

        static int[,] ValidRanges(int i, int j, int dim)
        {
            List<string> points = new List<string>();
            if (i + 1 < dim)
            {
                points.Add($"{i + 1} {j}");
            }
            if (i + 1 < dim && j + 1 < dim)
            {
                points.Add($"{i + 1} {j + 1}");
            }
            if (i + 1 < dim && j - 1 >= 0)
            {
                points.Add($"{i + 1} {j - 1}");
            }
            if (j - 1 >= 0)
            {
                points.Add($"{i} {j - 1}");
            }
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                points.Add($"{i - 1} {j - 1}");
            }
            if (i - 1 >= 0)
            {
                points.Add($"{i - 1} {j}");
            }
            if (i - 1 >= 0 && j + 1 < dim)
            {
                points.Add($"{i - 1} {j + 1}");
            }
            if (j + 1 < dim)
            {
                points.Add($"{i} {j + 1}");
            }

            int[,] result = new int[points.Count, 2];
            for (int k = 0; k < result.GetLength(0); k++)
            {
                int[] point = points[k].Split().Select(int.Parse).ToArray();
                result[k, 0] = point[0];
                result[k, 1] = point[1];
            }

            return result;
        }

        static int[,] Init()
        {
            int dim = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }

        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += $"{matrix[i, j]} ";
                }
                Console.WriteLine(line.Trim());
            }
        }

        static int GetAliveCount(int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        result++;
                }

            }
            return result;
        }

        static int GetAliveSum(int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        result += matrix[i, j];
                }

            }
            return result;
        }

    }
}
