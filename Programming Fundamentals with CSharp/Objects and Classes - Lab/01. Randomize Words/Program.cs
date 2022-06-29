using System;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            Random rand = new Random();
            for (int i = 0; i < line.Length; i++)
            {
                string temp = line[i];
                int randIndex = rand.Next(0, line.Length);
                line[i] = line[randIndex];
                line[randIndex] = temp;
            }
            Console.WriteLine(string.Join(' ', line));

        }
    }
}
