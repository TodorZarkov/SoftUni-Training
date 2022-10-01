using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = Init();

            int removed = 0;
            if (board.GetLength(0) < 3)
            {
                Console.WriteLine(removed);
                return;
            }

            int[] knightToRemove = new int[2];
            int surrKnights = MaxSurrKnights(board, knightToRemove);
            while (surrKnights != 0)
            {
                board[knightToRemove[0], knightToRemove[1]] = '0';
                removed++;

                surrKnights = MaxSurrKnights(board, knightToRemove);
            }


            Console.WriteLine(removed);
            //Print(board);
        }

        static int MaxSurrKnights(char[,] board, int[] maxCoord)
        {
            int maxKnightRow = -1;
            int maxKnightCol = -1;
            int maxSurrKnights = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '0')
                    {
                        int[,] valid = ValidMoves(i, j, board.GetLength(0));

                        int tempSurr = 0;

                        for (int k = 0; k < valid.GetLength(0); k++)
                        {
                            int validRow = valid[k, 0];
                            int validCol = valid[k, 1];
                            if (board[i, j] == board[validRow, validCol])
                            {
                                tempSurr++;
                            }
                        }
                        if (tempSurr > maxSurrKnights)
                        {
                            maxSurrKnights = tempSurr;
                            maxKnightRow = i;
                            maxKnightCol = j;
                        }
                    }
                }
            }
            maxCoord[0] = maxKnightRow;
            maxCoord[1] = maxKnightCol;
            return maxSurrKnights;
        }

        static int[,] ValidMoves(int i, int j, int dim)
        {
            List<string> points = new List<string>();
            if (i + 1 < dim && j + 2 < dim)
            {
                points.Add($"{i + 1} {j + 2}");
            }
            if (i + 2 < dim && j + 1 < dim)
            {
                points.Add($"{i + 2} {j + 1}");
            }
            if (i + 2 < dim && j - 1 >= 0)
            {
                points.Add($"{i + 2} {j - 1}");
            }
            if (i + 1 < dim && j - 2 >= 0)
            {
                points.Add($"{i + 1} {j - 2}");
            }
            if (i - 1 >= 0 && j - 2 >= 0)
            {
                points.Add($"{i - 1} {j - 2}");
            }
            if (i - 2 >= 0 && j - 1 >= 0)
            {
                points.Add($"{i - 2} {j - 1}");
            }
            if (i - 2 >= 0 && j + 1 < dim)
            {
                points.Add($"{i - 2} {j + 1}");
            }
            if (i - 1 >= 0 && j + 2 < dim)
            {
                points.Add($"{i - 1} {j + 2}");
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

        static void Print(char[,] matrix)
        {
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

        static char[,] Init()
        {
            int dim = int.Parse(Console.ReadLine());

            char[,] board = new char[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < dim; j++)
                {
                    board[i, j] = row[j];
                }
            }
            return board;
        }
    }
}
