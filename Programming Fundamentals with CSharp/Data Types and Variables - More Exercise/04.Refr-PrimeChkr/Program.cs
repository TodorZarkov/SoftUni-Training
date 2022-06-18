using System;

namespace _04.Refr_PrimeChkr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            for (int numToCheck = 2; numToCheck <= range; numToCheck++)
            {
                bool isPrime = true;

                for (int divider = 2; divider < numToCheck; divider++)
                {
                    if (numToCheck % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{numToCheck} -> {isPrime.ToString().ToLower()}");

            }


        }
    }
}
