using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            Analize(matrix);

            string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (line[0] != "End")
            {
                Manipulate(matrix, line);
                line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            //PRINT JUGGED
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }

        static void Analize(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    matrix[i] = matrix[i].Select((x => x * 2)).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select((x => x * 2)).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }

        static void Manipulate(int[][] matrix, string[] line)
        {
            string command = line[0];
                int row = int.Parse(line[1]);
                int col = int.Parse(line[2]);
                int value = int.Parse(line[3]);

                switch (command)
                {
                    case "Add":
                        if (row >= 0 && row < matrix.Length)
                        {
                            if (matrix[row].Length > col && col >= 0)
                            {
                                matrix[row][col] += value;
                            }
                        }

                        break;
                    case "Subtract":
                        if (row >= 0 && row < matrix.Length)
                        {
                            if (matrix[row].Length > col && col >= 0)
                            {
                                matrix[row][col] -= value;
                            }
                        }
                        break; ;
                }
        }

    }
}
