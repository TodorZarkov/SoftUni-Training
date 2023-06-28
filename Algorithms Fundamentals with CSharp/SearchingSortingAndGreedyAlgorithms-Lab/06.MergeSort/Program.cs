namespace _06.MergeSort
{
    using System;
    using System.Collections.Generic;
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
            int rightStart = ((start + end) / 2) + 1;
            int rightEnd = end;

            MergeSort(numbers, leftStart, leftEnd);
            MergeSort(numbers, rightStart, rightEnd);

            int left = leftStart;
            int right = rightStart;
            List<int> helpList = new List<int>(rightEnd - leftStart + 1);
            while (left <= leftEnd && right <= rightEnd)
            {
                if (numbers[left] > numbers[right])
                {
                    // insert before left
                    helpList.Add(numbers[right]);
                    right++;

                }
                else if (numbers[left] <= numbers[right])
                {
                    //insert after left
                    helpList.Add(numbers[left]);
                    left++;

                }

            }
            for (int i = left; i <= leftEnd; i++)
            {
                helpList.Add(numbers[i]);
            }
            for (int i = right; i <= rightEnd; i++)
            {
                helpList.Add(numbers[i]);
            }

            helpList.CopyTo(numbers, leftStart);
        }

        private static void Swap(List<int> helpList, int left, int right)
        {
            (helpList[left], helpList[right]) = (helpList[right], helpList[left]);
        }
    }
}
