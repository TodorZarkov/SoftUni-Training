using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dims[0];
            int cols = dims[1];

            string snake = Console.ReadLine();//no empty spaces expected
            char[,] matrix = new char[rows, cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                        matrix[i, j] = snake[index];
                        index++;
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                        matrix[i, j] = snake[index];
                        index++;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += $"{matrix[i, j]}";
                }
                Console.WriteLine(line.Trim());
            }

        }
    }
}
