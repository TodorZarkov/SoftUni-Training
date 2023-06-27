namespace _05.Quicksort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(n => int.Parse(n))
                .ToArray();
            LinkedList<int> numbers = new LinkedList<int>(input);

            Quicksort(numbers.First, numbers.Last, numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort(
            LinkedListNode<int> start,
            LinkedListNode<int> end, 
            LinkedList<int> numbers)
        {
            if (start == null || end  == null || start == end)
            {
                return;
            }

            var pivot = start;
            var node = start.Next;
            var isFirstSwap = true;
            while (node  != null && node != end.Next)
            {
                if (node.Value < pivot.Value)
                {
                    var nodeToMove = node;
                    node = node.Next;
                    numbers.AddBefore(pivot, nodeToMove.Value);
                    if (nodeToMove.Next == null)
                    {
                        end = nodeToMove.Previous;
                    }
                    numbers.Remove(nodeToMove);
                    if (isFirstSwap)
                    {
                        isFirstSwap = false;
                        start = pivot.Previous;
                    }
                }
                else
                {
                    node = node.Next;
                }
            }
            Quicksort(start, pivot, numbers);
            Quicksort(pivot.Next, end, numbers);
        }
    }
}
