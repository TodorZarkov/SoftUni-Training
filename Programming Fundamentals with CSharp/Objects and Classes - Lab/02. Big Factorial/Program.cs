using System;
using System.Numerics;

namespace _02._Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));

        }
        static BigInteger Factorial(BigInteger n)
        {
            if (n == 1) return n;
            return Factorial(n - 1) * n;
        }
    }
}
