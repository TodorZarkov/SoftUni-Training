using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbersReversed = new int[n];
            int reverseCounter = n;
            for (int i = 0; i < n; i++)
            {
                reverseCounter--;
                numbersReversed[reverseCounter] = int.Parse(Console.ReadLine());
            }
            
            Console.WriteLine(String.Join(' ',numbersReversed));
        }
    }
}
