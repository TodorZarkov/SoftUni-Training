using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> directions = new Queue<string>();
            char[,] field = Init(directions);
            int countCoal = CountCoal(field);
            int initCount = countCoal;
            int[] point = GetStart(field);

            while (directions.Count > 0 && countCoal > 0)
            {
                int move = Move(field, point, directions.Dequeue());

                if (move == -1)
                {
                    Console.WriteLine($"Game over! ({point[0]}, {point[1]})");
                    return;
                }

                countCoal -= move;
            }

            if (countCoal == 0)
            {
                Console.WriteLine($"You collected all coals! ({point[0]}, {point[1]})");
            }
            else if(directions.Count == 0)
            {
                Console.WriteLine($"{initCount - countCoal} coals left. ({point[0]}, {point[1]})");
            }
        }





        static int[] GetStart(char[,] matrix)
        {
            int[] result = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
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


        static int CountCoal(char[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 'c')
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        // -1 - 'e'(end), [0-max] - collected coal, current point
        static int Move(char[,] field, int[] point, string dir)
        {
            int coalFound = 0;
            int row = point[0];
            int col = point[1];
            switch (dir)
            {
                case "right":
                    if (col + 1 < field.GetLength(0))
                    {
                        col++;
                        if (field[row,col] == 'c')
                        {
                            coalFound++;
                            field[row, col] = '*';
                        }
                        else if (field[row, col] == 'e')
                        {
                            point[0] = row;
                            point[1] = col;
                            return -1;
                        }
                    }
                    break;
                case "down":
                    if (row + 1 < field.GetLength(0))
                    {
                        row++;
                        if (field[row, col] == 'c')
                        {
                            coalFound++;
                            field[row, col] = '*';
                        }
                        else if (field[row, col] == 'e')
                        {
                            point[0] = row;
                            point[1] = col;
                            return -1;
                        }
                    }
                    break;
                case "left":
                    if (col - 1 >= 0)
                    {
                        col--;
                        if (field[row, col] == 'c')
                        {
                            coalFound++;
                            field[row, col] = '*';
                        }
                        else if (field[row, col] == 'e')
                        {
                            point[0] = row;
                            point[1] = col;
                            return -1;
                        }
                    }
                    break;
                case "up":
                    if (row - 1 >= 0)
                    {
                        row--;
                        if (field[row, col] == 'c')
                        {
                            coalFound++;
                            field[row, col] = '*';
                        }
                        else if (field[row, col] == 'e')
                        {
                            point[0] = row;
                            point[1] = col;
                            return -1;
                        }
                    }
                    break;
            }


            point[0] = row;
            point[1] = col;
            return coalFound;
        }

        static char[,] Init(Queue<string> directions)
        {
            int dim = int.Parse(Console.ReadLine());

            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(d => directions.Enqueue(d));

            char[,] board = new char[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                char[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray(); ;
                for (int j = 0; j < dim; j++)
                {
                    board[i, j] = row[j];
                }
            }
            return board;
        }

    }
}
