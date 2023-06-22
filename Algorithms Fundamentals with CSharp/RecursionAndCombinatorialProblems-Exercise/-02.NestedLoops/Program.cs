namespace _02.NestedLoops
{
    using System;

    internal class Program
    {
        private static int[] elements;
        private static int[] variations;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            elements = new int[n];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = i + 1;
            }
            variations = new int[n];

            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {

                for (int i = 0; i < elements.Length; i++)
                {
                    variations[index] = elements[i];
                    Variate(index + 1);
                }
            }


        }


    }
}
