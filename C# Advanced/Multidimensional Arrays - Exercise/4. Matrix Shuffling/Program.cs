using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dims[0];
            int cols = dims[1];
            string[][] matrix = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            //Regex rx = new Regex(@"\s*swap\s*(?<coord>\s+\d+){4}\s*");
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                bool validInput = false;
                if (input.Length == 5 &&
                    input[0] == "swap" &&
                    int.Parse(input[1])< rows &&
                    int.Parse(input[3]) < rows &&
                    int.Parse(input[2]) < cols &&
                    int.Parse(input[4]) < cols)
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (int.Parse(input[i]) >= 0)
                        {
                            validInput = true;
                        }
                    }
                }

                if (validInput)
                {
                    int row1 = int.Parse(input[1]);
                    int row2 = int.Parse(input[3]);
                    int col1 = int.Parse(input[2]);
                    int col2 = int.Parse(input[4]);
                    string temp = matrix[row1][col1];
                    matrix[row1][col1] = matrix[row2][col2];
                    matrix[row2][col2] = temp;
                    for (int i = 0; i < rows; i++)
                    {
                        string line = "";
                        for (int j = 0; j < cols; j++)
                        {
                            line += $"{matrix[i][j]} ";
                        }
                        line.Trim();
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }



        }

        
    }
}
