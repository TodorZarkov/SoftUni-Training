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
                lab[i] = Console.ReadLine().ToArray();
            }

            PrintLabyrinth(lab);
        }

        private static void PrintLabyrinth(char[][] lab)
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    Console.WriteLine(lab[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}