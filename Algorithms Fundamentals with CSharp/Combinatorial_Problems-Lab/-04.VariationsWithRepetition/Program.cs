namespace _04.VariationsWithRepetition
{
    using System;
    using System.Linq;


    public class Program
    {
        private static string[] variations;

        private static string[] elements;

        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ").ToArray();
            int k = int.Parse(Console.ReadLine());
            variations = new string[k];
            used = new bool[elements.Length];
            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= variations.Length)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {


                    used[i] = true;
                    variations[index] = elements[i];
                    Variate(index + 1);
                    used[i] = false;

                }
            }
        }
        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variations));
        }
    }
}
