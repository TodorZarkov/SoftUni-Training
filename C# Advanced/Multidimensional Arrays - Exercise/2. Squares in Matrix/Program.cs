using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', cols, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int squares = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int currElement = matrix[i][j];
                    if (currElement == matrix[i][j + 1])
                    {
                        if (currElement == matrix[i + 1][j])
                        {
                            if (currElement == matrix[i + 1][j + 1])
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
