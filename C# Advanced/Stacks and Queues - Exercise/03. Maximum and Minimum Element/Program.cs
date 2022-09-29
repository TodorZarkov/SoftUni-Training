using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Queue<int[]> queries = new Queue<int[]>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queries.Enqueue(query);
            }

            Stack<int> numbers = new Stack<int>();
            while (queries.Count > 0)
            {
                int[] query = queries.Dequeue();
                switch (query[0])
                {
                    case 1:
                        numbers.Push(query[1]);
                        break;
                    case 2:
                        if (numbers.Count != 0)
                            numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count != 0)
                            Console.WriteLine(numbers.Max());
                        break;
                    case 4:
                        if (numbers.Count != 0)
                            Console.WriteLine(numbers.Min());
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
