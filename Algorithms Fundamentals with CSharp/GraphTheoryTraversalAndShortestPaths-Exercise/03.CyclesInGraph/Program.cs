namespace _03.CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            var line = Console.ReadLine();
            while (line != "End")
            {
                var edge = line.Split('-');
                var from = edge[0];
                var to = edge[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<string>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<string>());
                }

                graph[from].Add(to);

                line = Console.ReadLine();
            }

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }
            
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}
