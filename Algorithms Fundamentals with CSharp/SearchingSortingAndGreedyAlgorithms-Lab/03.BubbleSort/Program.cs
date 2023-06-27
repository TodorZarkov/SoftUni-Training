namespace _03.BubbleSort
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

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool hasChanged = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                        hasChanged = true;
                    }
                }
                if (!hasChanged)
                {
                    break;
                }
                hasChanged = false;
            }
        }
    }
}
