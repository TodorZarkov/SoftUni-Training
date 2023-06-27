namespace _04.InsertionSort
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

            InsertionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i - 1;
                int min = i;
                while (j >= 0 && numbers[min] < numbers[j])
                {
                    (numbers[min], numbers[j]) = (numbers[j], numbers[min]);
                    min = j;
                    j--;
                }
            }
        }
    }
}
