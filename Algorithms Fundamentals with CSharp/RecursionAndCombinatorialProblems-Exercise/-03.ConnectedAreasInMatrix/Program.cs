namespace _03.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int visitedCount;
        private static SortedSet<Area> areas;
        private static char[,] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            visitedCount = 0;
            areas = new SortedSet<Area>();
            matrix = new char[rows, cols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Visit(i, j);
                    if (visitedCount != 0)
                    {
                        Area area = new Area(visitedCount, i, j);
                        areas.Add(area);
                        visitedCount = 0;
                    }
                }
            }


            Console.WriteLine($"Total areas found: {areas.Count}");
            int f = 1;
            foreach (var area in areas)
            {
                Console.WriteLine(string.Format(area.ToString(),f));
                f++;
            }

        }

        private static void Visit(int i, int j)
        {
            if (
                i < 0 ||
                j < 0 ||
                i >= matrix.GetLength(0) ||
                j >= matrix.GetLength(1) ||
                matrix[i, j] == '*' ||
                matrix[i, j] == 'v')
            {
                return;
            }

            matrix[i, j] = 'v';
            visitedCount++;

            Visit(i + 1, j);
            Visit(i - 1, j);
            Visit(i, j + 1);
            Visit(i, j - 1);
        }
    }

    internal class Area : IComparable
    {
        private int visitedCount;
        private int i;
        private int j;

        public Area(int visitedCount, int i, int j)
        {
            this.visitedCount = visitedCount;
            this.i = i;
            this.j = j;
        }

        public override string ToString()
        {
            return $"Area #{{0}} at ({i}, {j}), size: {visitedCount}";
        }

        public int CompareTo(object obj)
        {
            if (visitedCount < ((Area)obj).visitedCount)
            {
                return 1;
            }
            else if (visitedCount > ((Area)obj).visitedCount)
            {
                return -1;
            }

            if (i < ((Area)obj).i)
            {
                return -1;
            }
            else if (i > ((Area)obj).i)
            {
                return 1;
            }

            if (j < ((Area)obj).j)
            {
                return -1;
            }
            else //if (j < ((Area)obj).j)
            {
                return 1;
            }

        }
    }
}
