﻿namespace DijkstrasAlgorithm
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Wintellect.PowerCollections;

	public class Program
	{
		private static Dictionary<int, List<Edge>> edgesByNode;
		private static double[] distance;
		private static int[] parent;  

		static void Main(string[] args)
		{
			edgesByNode = new Dictionary<int, List<Edge>>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeArgs = Console.ReadLine()
					.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();
				int firstNode = edgeArgs[0];
				int secondNode = edgeArgs[1];

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeArgs[2]
				};

				if (!edgesByNode.ContainsKey(firstNode))
				{
					edgesByNode.Add(firstNode, new List<Edge>());
				}
				if (!edgesByNode.ContainsKey(secondNode))
				{
					edgesByNode.Add(secondNode, new List<Edge>());
				}

				edgesByNode[firstNode].Add(edge);
				edgesByNode[secondNode].Add(edge);
			}



			int biggestNode = edgesByNode.Keys.Max();

			distance = new double[biggestNode + 1];
			for (int i = 0; i < distance.Length; i++)
			{
				distance[i] = double.PositiveInfinity;
			}



			int startNode = int.Parse(Console.ReadLine());
			int endNode = int.Parse(Console.ReadLine());

			parent = new int[biggestNode + 1];
			Array.Fill(parent, -1);
			for (int i = 0; i < parent.Length; i++)
			{
				parent[i] = -1;
			}

			distance[startNode] = 0;

			OrderedBag<int> bag = new OrderedBag<int>(
				Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
			bag.Add(startNode);

			while (bag.Count > 0)
			{
				int minNode = bag.RemoveFirst();

				if (double.IsPositiveInfinity(minNode) || minNode == endNode)
				{
					break;
				}

				foreach (Edge edge in edgesByNode[minNode])
				{
					int otherNode = edge.First == minNode ? edge.Second : edge.First;

					if (double.IsPositiveInfinity(distance[otherNode]))
					{
						bag.Add(otherNode);
					}

					double newDistance = distance[minNode] + edge.Weight;

					if (newDistance < distance[otherNode])
					{
						parent[otherNode] = minNode;
						distance[otherNode] = newDistance;
						bag = new OrderedBag<int>(bag,
				Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
					}

				}
			}

			if (distance[endNode] == double.PositiveInfinity)
			{
                Console.WriteLine("There is no such path.");
				return;
            }

			Console.WriteLine(distance[endNode]);

			int currentNode = endNode;
			Stack<int> path = new Stack<int>();
			while (currentNode!=  -1)
			{
				path.Push(currentNode);
				currentNode = parent[currentNode];
			}
            Console.WriteLine(string.Join(" ", path));
        }

	}

	public class Edge
	{
		public int First { get; set; }

		public int Second { get; set; }

		public int Weight { get; set; }
	}
}
