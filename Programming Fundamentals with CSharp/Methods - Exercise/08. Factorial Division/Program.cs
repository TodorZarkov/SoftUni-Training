using System;
using System.Numerics;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BigInteger a = int.Parse(Console.ReadLine());
            BigInteger b = int.Parse(Console.ReadLine());
            //Calculate the factorial of each number.
            //Divide the first result by the second and
            //print the result of the division formatted to the second decimal point.
            Console.WriteLine($"{Division(Factorial(a), Factorial(b)):f2}");
        }
        static decimal Division(BigInteger a, BigInteger b)
        {
            return (decimal)a / (decimal)b;
        }
        static BigInteger Factorial(BigInteger a)
        {
            if (a == 1)
            {
                return a;
            }
            return a * Factorial(a - 1);
        }
    }
}
