using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int pushes = data[0];
            int pops = data[1];
            int toCheck = data[2];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < pushes; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < pops; i++)
            {
                stack.Pop();
            }
            bool isPresent = stack.Contains(toCheck);
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (isPresent)
            {
                Console.WriteLine(isPresent.ToString().ToLower());
            }
            else
            {
                List<int> list = stack.ToList();
                list.Sort();
                Console.WriteLine(list.First());
            }
        }
    }
}
