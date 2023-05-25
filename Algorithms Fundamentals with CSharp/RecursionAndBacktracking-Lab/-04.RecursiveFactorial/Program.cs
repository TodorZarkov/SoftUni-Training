namespace _04.RecursiveFactorial
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());

            ulong result =  RecursiveFactorial(n);

            Console.WriteLine(result);
        }

        private static ulong RecursiveFactorial(ulong n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * RecursiveFactorial(n - 1);
        }
    }
}