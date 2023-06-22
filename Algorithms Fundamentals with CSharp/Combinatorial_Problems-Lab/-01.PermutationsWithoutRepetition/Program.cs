namespace _01.PermutationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ").ToArray();
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Print();
            } 
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            (elements[i], elements[index]) = (elements[index], elements[i]);
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
