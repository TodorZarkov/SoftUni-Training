using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            int distance = 0;
            Tuple<int, int> p = new Tuple<int, int>(0, 0);


            string[][] matrix = new string[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string direction = Console.ReadLine();
            while (direction != "End")
            {
                p = getNextPositionFromDirection(direction, p);
                if (matrix[p.Item1][p.Item2] == "T")
                {
                    distance += 30;
                    matrix[p.Item1][p.Item2] = ".";
                    p = findPositionOf("T", matrix);
                    matrix[p.Item1][p.Item2] = ".";
                }
                else if (matrix[p.Item1][p.Item2] == "F")
                {
                    distance += 10;
                    break;
                }
                else
                {
                    distance += 10;
                }

                direction = Console.ReadLine();
            }

            if (matrix[p.Item1][p.Item2] == "F")
            {
                matrix[p.Item1][p.Item2] = "C";
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                Console.WriteLine($"Distance covered {distance} km.");
                print(matrix);
            }
            else if (matrix[p.Item1][p.Item2] == ".")
            {
                matrix[p.Item1][p.Item2] = "C";
                Console.WriteLine($"Racing car {racingNumber} DNF.");
                Console.WriteLine($"Distance covered {distance} km.");
                print(matrix);
            }


        }




        static void print(string[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {

                sb.AppendLine(string.Join("", matrix[i]));
            }
            Console.Write(sb.ToString());
        }

        static Tuple<int, int> findPositionOf(string place, string[][] matrix)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < matrix.Length; i++)
            {
                for (j = 0; j < matrix.Length; j++)
                {
                    if (matrix[i][j] == place)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

        static Tuple<int, int> getNextPositionFromDirection(string direction, Tuple<int, int> current)
        {
            switch (direction)
            {
                case "left":
                    return new Tuple<int, int>(current.Item1, current.Item2 - 1);
                case "right":
                    return new Tuple<int, int>(current.Item1, current.Item2 + 1);
                case "up":
                    return new Tuple<int, int>(current.Item1 - 1, current.Item2);
                case "down":
                    return new Tuple<int, int>(current.Item1 + 1, current.Item2);

            }
            return null;
        }
    }
}
