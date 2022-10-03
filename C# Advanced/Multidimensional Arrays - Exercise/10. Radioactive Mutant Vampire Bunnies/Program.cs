using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> directions = new Queue<char>();
            char[,] lair = Init(directions);
            int[] curPoint = GetPlayerPosition(lair);

            string status = "";
            do
            {
                status = Move(GetOffsetFrom(directions.Dequeue()), curPoint, lair);
                if (status != "HAS DIED")
                    Spread(lair);
            }
            while (status == "MOVES");

            Print(lair);

            if (status == "OUT")
            {
                Console.WriteLine($"won: {curPoint[0]} {curPoint[1]}");
            }
            else if (status == "DEAD")
            {
                Console.WriteLine($"dead: {curPoint[0]} {curPoint[1]}");
            }
        }

        static void Spread(char[,] lair)
        {
            Queue<int[]> bunnies = GetBunnies(lair);
            while (bunnies.Count > 0)
            {
                int rowB = bunnies.Peek()[0];
                int colB = bunnies.Peek()[1];
                bunnies.Dequeue();

                int[,] valid = ValidRanges(rowB, colB, lair.GetLength(0), lair.GetLength(1));
                for (int i = 0; i < valid.GetLength(0); i++)
                {
                    int vRow = valid[i, 0];
                    int vCol = valid[i, 1];
                    if (lair[vRow, vCol] != 'B')
                    {
                        lair[vRow, vCol] = 'B';
                    }
                }
            }
        }

        static string Move(int[] offset, int[] curPoint, char[,] lair)
        {
            string result = "MOVES";
            //A Bunny has moved over the player
            if (lair[curPoint[0], curPoint[1]] == 'B')
            {
                result = "HAS DIED";
            }
            else if (isOut(curPoint[0] + offset[0], curPoint[1] + offset[1], lair.GetLength(0), lair.GetLength(1)))
            {
                lair[curPoint[0], curPoint[1]] = '.';
                result = "OUT";
            }//Moves to Bunny
            else if (lair[curPoint[0] + offset[0], curPoint[1] + offset[1]] == 'B')
            {
                lair[curPoint[0], curPoint[1]] = '.';
                curPoint[0] += offset[0];
                curPoint[1] += offset[1];
                result = "DEAD";
            }
            else //Player Moves
            {
                lair[curPoint[0], curPoint[1]] = '.';
                lair[curPoint[0] + offset[0], curPoint[1] + offset[1]] = 'P';
                curPoint[0] += offset[0];
                curPoint[1] += offset[1];
            }

            return result;
        }


        static int[] GetPlayerPosition(char[,] matrix)
        {
            int[] position = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }
            return position;
        }


        static char[,] Init(Queue<char> commands)
        {
            int[] dims = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dims[0];
            int cols = dims[1];

            char[,] lairOut = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string col = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    lairOut[i, j] = col[j];
                }
            }

            string line = Console.ReadLine();
            foreach (char command in line)
            {
                commands.Enqueue(command);
            }

            return lairOut;
        }


        static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row += $"{matrix[i, j]}";
                }
                Console.WriteLine(row);
            }
        }


        static bool isOut(int i, int j, int rows, int cols)
        {
            if (i < 0) return true;
            if (j < 0) return true;
            if (i >= rows) return true;
            if (j >= cols) return true;
            return false;
        }


        static int[,] ValidRanges(int i, int j, int dimRows, int dimCols)
        {
            List<string> points = new List<string>();
            if (i + 1 < dimRows)
            {
                points.Add($"{i + 1} {j}");
            }
            if (j - 1 >= 0)
            {
                points.Add($"{i} {j - 1}");
            }
            if (i - 1 >= 0)
            {
                points.Add($"{i - 1} {j}");
            }
            if (j + 1 < dimCols)
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

        static Queue<int[]> GetBunnies(char[,] matrix)
        {
            Queue<int[]> bunnies = new Queue<int[]>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        int[] position = new int[2];
                        position[0] = i;
                        position[1] = j;
                        bunnies.Enqueue(position);
                    }
                }
            }
            return bunnies;
        }

        static int[] GetOffsetFrom(char direction)
        {
            int[] result = new int[2];
            switch (direction)
            {
                case 'R':
                    result[0] = 0;
                    result[1] = 1;
                    break;
                case 'L':
                    result[0] = 0;
                    result[1] = -1;
                    break;
                case 'U':
                    result[0] = -1;
                    result[1] = 0;
                    break;
                case 'D':
                    result[0] = 1;
                    result[1] = 0;
                    break;

            }
            return result;
        }
    }
}
