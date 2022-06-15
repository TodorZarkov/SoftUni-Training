using System;

namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOdds = int.Parse(Console.ReadLine());
            int sum = 0;
            int oddNumber = 1 ;
            for (int i = 1; i <= countOdds; i++)
            {
                Console.WriteLine(oddNumber);
                sum += oddNumber;
                oddNumber += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
