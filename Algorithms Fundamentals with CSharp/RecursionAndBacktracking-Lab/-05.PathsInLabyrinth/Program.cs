namespace _05.PathsInLabyrinth
{
	using System;
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

		private static void GoNext(int x, int y, string step, char[][] lab, Stack<string> path)
		{
			if (x < 0 || y < 0 || x > lab.Length - 1 || y > lab[x].Length - 1)
			{
				return;
			}

			if (lab[x][y] == 'e')
			{
				Console.WriteLine(string.Join("", path));
				return;
			}

			if (lab[x][y] == 'v')
			{
				return;
			}

			if (lab[x][y] == '*')
			{
				return;
			}

			lab[x][y] = 'v';
			path.Push(step);

			GoNext(x + 1, y, "R", lab, path); //right
			GoNext(x - 1, y, "L", lab, path); //left
			GoNext(x, y + 1, "U", lab, path); //up
			GoNext(x, y - 1, "D", lab, path); //down

			if (lab[x][y] == 'v')
			{
				lab[x][y] = '-';
				path.Pop();
			}
		}

		private static void PrintLabyrinth(char[][] lab)
		{
			for (int i = 0; i < lab.Length; i++)
			{
				Console.WriteLine(string.Join("", lab[i]));
			}
		}
	}
}