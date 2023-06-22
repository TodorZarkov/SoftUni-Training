namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ").Select(e => int.Parse(e)).ToArray();

            Reverse(0);
        }

        private static void Reverse(int index)
        {
            if (index >= elements.Length/2)
            {
                Console.WriteLine(string.Join(" ",elements));
                return;
            }
            (elements[index], elements[elements.Length - 1 - index]) = 
                (elements[elements.Length - 1 - index], elements[index]);
            Reverse(index + 1);
        }
    }
}
