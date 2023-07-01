namespace _02.Chainalysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, bool> visited;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();

            visited = new Dictionary<string, bool>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split()
                    .ToArray();
                string node = data[0];
                string child = data[1];
                //int coins = int.Parse(data[2]);


                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<string>();
                }
                graph[node].Add(child);

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<string>();
                }
                graph[child].Add(node);
            }

            int components = 0;
            foreach (string node in graph.Keys)
            {
                if (visited.ContainsKey(node))
                {
                    continue;
                }
                List<string> component = new List<string>();
                DFS(node, component);
                components++;
                //Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
            Console.WriteLine(components);
        }

        private static void DFS(string node, List<string> component)
        {
            if (visited.ContainsKey(node))
            {
                return;
            }

            visited[node] = true;

            foreach (string child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}
