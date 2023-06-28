namespace _06.MergeSort
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(n => int.Parse(n))
                .ToArray();

            MergeSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void MergeSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int leftStart = start;
            int leftEnd = (start + end) / 2;
            int rightStart = ((start + end) / 2) +1;
            int rightEnd = end;
            MergeSort(numbers, leftStart, leftEnd);
            MergeSort(numbers, rightStart, rightEnd);
        }
    }
}
