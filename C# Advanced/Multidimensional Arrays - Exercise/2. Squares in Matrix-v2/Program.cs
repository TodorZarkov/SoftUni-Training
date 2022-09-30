using System;
using System.Linq;

namespace _2._Squares_in_Matrix_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int squares = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    char currElement = matrix[i][j];
                    if (matrix[i][j] == matrix[i][j + 1])
                    {
                        if (matrix[i][j] == matrix[i + 1][j])
                        {
                            if (matrix[i][j] == matrix[i + 1][j + 1])
                            {
                                squares++;
                            }
                        }
                    }
                }
            }


            Console.WriteLine(squares);
        }
    }
}
