using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            int[] arr = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();
            bool isTop = true;
            for (int i = 0; i < arr.Length; i++)
            {
                isTop = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
