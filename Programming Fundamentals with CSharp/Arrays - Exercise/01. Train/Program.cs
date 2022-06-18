using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] passangers = new int[lines];
            for (int i = 0; i < lines; i++)
            {
                passangers[i] = int.Parse(Console.ReadLine());
            }
            int totalPassangers = 0;
            foreach (int item in passangers)
            {
                Console.Write(item + " ");
                totalPassangers += item;
            }
            Console.WriteLine();
            Console.WriteLine(totalPassangers);
        }
    }
}
