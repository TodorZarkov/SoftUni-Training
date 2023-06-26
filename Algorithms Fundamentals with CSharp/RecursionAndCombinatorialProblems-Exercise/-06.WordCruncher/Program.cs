namespace _06.WordCruncher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static string target;
        private static List<string> elements;
        private static Stack<string> combinations;
        private static HashSet<string> used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(", ").ToList();
            target = Console.ReadLine();
            combinations = new Stack<string>();
            used = new HashSet<string>();

            FormTarget(0, 1);
        }

        private static void FormTarget(int startIdx, int length)
        {
            if ((startIdx + length) > target.Length)
            {
                if (combinations.Sum(c => c.Length) == target.Length)
                {
                    Console.WriteLine(string.Join(" ", combinations.Reverse()));
                    return;
                }
                return;
            }

            string subTarget = target.Substring(startIdx, length);
            bool hasMatch = elements.Contains(subTarget);
            if (hasMatch)
            {
                combinations.Push(subTarget);
                elements.Remove(subTarget);
                used.Add(subTarget);
                FormTarget(startIdx + length, 1);
                combinations.Pop();
                elements.Add(subTarget);
                used.Remove(subTarget);

                FormTarget(startIdx, length + 1);
            }
            else
            {
                FormTarget(startIdx, length + 1);
            }
        }
    }
}
