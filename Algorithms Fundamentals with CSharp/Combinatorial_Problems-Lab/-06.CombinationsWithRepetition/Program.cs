namespace _06.CombinationsWithRepetition
{
    using System;
    using System.Linq;


    public class Program
    {
        private static int k;

        private static string[] combinations;

        private static string[] elements;


        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ").ToArray();
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            Combinate(0, 0);
        }

        private static void Combinate(int index, int elementStartIdx)
        {
            if (index >= combinations.Length)
            {
                Print();
                return;
            }

            for (int i = elementStartIdx; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combinate(index + 1, i);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", combinations));
        }

    }
}
