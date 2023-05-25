namespace _01.RecursiveArraySum
{
    using System;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int sum = RecursiveSum(numbers);

            Console.WriteLine(sum);
        }


        private static int RecursiveSum(int[] numbers, int index = 0)
        {
            if(index >= numbers.Length-1)
            {
                return numbers[index];
            }

            return numbers[index] + RecursiveSum(numbers, index + 1);
        }
    }
}