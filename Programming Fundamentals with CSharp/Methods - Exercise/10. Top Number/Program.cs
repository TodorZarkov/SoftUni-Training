using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int endNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i < endNumber; i++)
            {
                if (IsSumDiv(i.ToString()) && ContainsOdd(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        //is sum of the digits divisible by 8
        static bool IsSumDiv(string num)
        {
            int sum = 0;
            //the digits in ascii are from 48(0) to 57(9)
            foreach (char digit in num)
            {
                sum += (int)(digit - 48);
            }
            return sum%8 == 0;
        }

        static bool ContainsOdd(string num)
        {
            foreach (char digit in num)
            {
                //the digits in ascii are from 48(0) to 57(9)
                if (digit % 2 != 0)
                    return true;
            }
            return false;
        }
    }
}
