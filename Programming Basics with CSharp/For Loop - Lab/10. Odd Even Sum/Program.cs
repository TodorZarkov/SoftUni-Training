using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;
            int num = 0;
            bool odd = true;
            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (odd)
                {
                    sumOdd += num; 
                    odd = false;
                }
                else
                {
                    sumEven += num;
                    odd = true;
                }
                    

            }
            int diff = sumOdd - sumEven;
            if (diff == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumOdd}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(diff)}");
            }
        }
    }
}
