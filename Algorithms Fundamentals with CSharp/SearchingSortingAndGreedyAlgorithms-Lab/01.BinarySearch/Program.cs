namespace _01.BinarySearch
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] sortedArray = Console.ReadLine()
                .Split(" ")
                .Select(e => int.Parse(e))
                .ToArray();

            int searchFor = int.Parse(Console.ReadLine());

            int result = BinarySearch(sortedArray, searchFor);

            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] sortedArray, int searchFor)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;
                if (sortedArray[mid] == searchFor)
                {
                    return mid;
                }
                else if (sortedArray[mid] > searchFor)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid  + 1;
                }
            }

            return -1;
        }
    }
}
