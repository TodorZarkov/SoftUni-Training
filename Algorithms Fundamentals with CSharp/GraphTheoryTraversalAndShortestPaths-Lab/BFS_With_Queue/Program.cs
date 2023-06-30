﻿namespace BFS_With_Queue
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static HashSet<int> visited;
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            visited = new HashSet<int>();
            graph = new Dictionary<int, List<int>>()
            {
                {1, new List<int>(){19,  21, 14} },
                {19, new List<int>(){7,  12, 31, 21} },
                {21, new List<int>(){14} },
                {14, new List<int>(){23,  6} },
                {7, new List<int>(){1} },
                {12, new List<int>() },
                {31, new List<int>(){21} },
                {23, new List<int>(){21} },
                {6, new List<int>()},
            };

            foreach (var node in graph.Keys)
            {
                BFS(node);
            }
        }

        private static void BFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            Queue<int> toVisit = new Queue<int>();
            toVisit.Enqueue(node);
            visited.Add(node);

            while (toVisit.Count > 0)
            {
                var endNode = toVisit.Dequeue();
                foreach (var child in graph[endNode])
                {
                    if (!visited.Contains(child))
                    {
                        toVisit.Enqueue(child);
                        visited.Add(child);
                    }
                }
                Console.WriteLine(endNode);
            }

        }
    }
}
