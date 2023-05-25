namespace _02.RecursiveDrawing
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            Draw(row);
        }

        private static void Draw(int row)
        {
            if (row == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', row));

            Draw(row - 1);

            Console.WriteLine(new string('#', row));
        }
    }
}