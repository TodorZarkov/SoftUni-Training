namespace _05.PathsInLabyrinth
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

    public class Program
	{
		static void Main(string[] args)
		{
			int height = int.Parse(Console.ReadLine());
			int width = int.Parse(Console.ReadLine());

			char[][] lab = new char[height][];
			for (int i = 0; i < height; i++)
			{
				lab[i] = Console.ReadLine().ToCharArray();
			}

			Stack<string> path = new Stack<string>();

			GoNext(0, 0, "", lab, path);

		}

		private static void GoNext(int y, int x, string step, char[][] lab, Stack<string> path)
		{
			if (x < 0 || y < 0 || y > lab.Length - 1 || x > lab[y].Length - 1)
			{
				return;
			}

			if (lab[y][x] == 'e')
			{
				path.Push(step);
				Console.WriteLine(string.Join("", path.Reverse()));
				path.Pop();
				return;
			}

			if (lab[y][x] == 'v')
			{
				return;
			}

			if (lab[y][x] == '*')
			{
				return;
			}

			lab[y][x] = 'v';
			path.Push(step);

			GoNext(y - 1, x, "U", lab, path); //up
			GoNext(y, x + 1, "R", lab, path); //right
			GoNext(y + 1, x, "D", lab, path); //down
			GoNext(y, x - 1, "L", lab, path); //left

			if (lab[y][x] == 'v')
			{
				lab[y][x] = '-';
				path.Pop();
			}
		}
	}
}