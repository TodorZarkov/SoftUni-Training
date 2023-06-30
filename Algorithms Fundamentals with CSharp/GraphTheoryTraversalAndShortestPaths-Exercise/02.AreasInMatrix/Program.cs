namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static char[][] graph;
        private static bool[][] visited;
        private static Dictionary<char, int> areas;
        private static bool isNewArea;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows][];
            visited = new bool[rows][];
            areas = new Dictionary<char, int>();
            isNewArea = false;

            for (int i = 0; i < rows; i++)
            {
                graph[i] = Console.ReadLine().ToCharArray();
                visited[i] = new bool[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    BFS(i, j, graph[i][j]);
                    if (isNewArea)
                    {
                        var current = graph[i][j];
                        if (!areas.ContainsKey(current))
                        {
                            areas[current] = 1;
                        }
                        else
                        {
                            areas[current]++;
                        }
                        isNewArea = false;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");
            var orderedAreas = areas.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);
            foreach (var area in orderedAreas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void BFS(int i, int j,  char current)
        {
            if (i < 0 || j < 0 || i > visited.Length-1 || j > visited[i].Length-1 || visited[i][j])
            {
                return;
            }

            if (graph[i][j] != current)
            {
                return;
            }

            visited[i][j] = true;
            isNewArea = true;

            BFS(i + 1, j, current);
            BFS(i - 1, j, current);
            BFS(i, j + 1, current);
            BFS(i, j - 1, current);

            
        }
    }
}
