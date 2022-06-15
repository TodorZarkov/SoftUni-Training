using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            while (a <= b)
            {
                string current = a.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (i%2 == 0)
                    {
                        evenSum += current[i];
                    }
                    else
                    {
                        oddSum += current[i];
                    }
                }
                if(oddSum == evenSum)
                    Console.Write(current + " ");

                a++;
            }
        }
    }
}
