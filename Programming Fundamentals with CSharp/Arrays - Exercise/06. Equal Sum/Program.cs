using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            int[] arr = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();
            bool exist = true;
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = i+1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }
                for (int k = i-1; k >= 0; k--)
                {
                    leftSum += arr[k];
                }
                if (leftSum == rightSum)
                {
                    exist = true;
                    index = i;
                    break;
                }
                else
                {
                    exist = false;
                }
            }
            if (exist)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
