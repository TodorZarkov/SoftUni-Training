namespace Quicksort_left_right_pointer
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

            Quicksort_left_right_pointer(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort_left_right_pointer(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;
            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] <= numbers[pivot])
                {
                    Swap(numbers, left, right);
                }
                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }
                if (numbers[right] > numbers[pivot])
                {
                    right--;
                }
            }
            Swap(numbers, pivot, right);

            var firstStart = start;
            var firstEnd = right - 1;
            var secondStart = right + 1;
            var secondEnd = end;
            if ((firstEnd - firstStart) < (secondEnd - secondStart))
            {
                Quicksort_left_right_pointer(numbers, firstStart, firstEnd);
                Quicksort_left_right_pointer(numbers, secondStart, secondEnd);
            }
            else
            {
                Quicksort_left_right_pointer(numbers, secondStart, secondEnd);
                Quicksort_left_right_pointer(numbers, firstStart, firstEnd);
            }
        }

        private static void Swap(int[] numbers, int left, int right)
        {
            (numbers[left], numbers[right]) = (numbers[right], numbers[left]);
        }
    }
}
