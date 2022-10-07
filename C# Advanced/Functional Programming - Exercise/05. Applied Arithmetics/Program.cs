using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => 2 * x;
            Func<int, int> subtract = x => x - 1;
            Action<int[]> print = x => { Console.WriteLine(String.Join(' ', x)); return; };

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string line = Console.ReadLine();
            while (line != "end")
            {
                Func<int,int> operation = line == "add" ? add : line == "multiply" ? multiply : line == "subtract" ? subtract : null;
                if (line == "print")
                {
                    print(numbers);
                }
                else
                {
                    Calculate(numbers, operation);
                }
                line = Console.ReadLine();
            }
        }
        static void Calculate(int[] numbers, Func<int, int> op)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = op(numbers[i]);
            }
        }
    }
}
