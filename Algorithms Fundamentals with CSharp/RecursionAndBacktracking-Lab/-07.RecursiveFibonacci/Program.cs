namespace _07.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static Dictionary<int,long> fibonaccies = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (n > 91)
            {
                throw new OverflowException($"Reached long max value (${long.MaxValue}");
            }
            if (n < 2)
            {
                return 1;
            }
            if (fibonaccies.ContainsKey(n))
            {
                return fibonaccies[n];
            }
            long result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            fibonaccies[n] = result;
            
            return result;
        }
    }
}
