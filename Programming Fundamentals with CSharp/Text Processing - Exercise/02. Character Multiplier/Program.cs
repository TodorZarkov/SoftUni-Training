using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            string strA = text[0];
            string strB = text[1];

            int minLen = strA.Length < strB.Length ? strA.Length : strB.Length;
            int sum = 0;
            for (int i = 0; i < minLen; i++)
            {
                sum += (int)strA[i] * (int)strB[i];
            }
            if (strA.Length > strB.Length)
            {
                for (int i = minLen; i < strA.Length; i++)
                {
                    sum += (int)strA[i];
                }
            }
            else if (strA.Length < strB.Length)
            {
                for (int i = minLen; i < strB.Length; i++)
                {
                    sum += (int)strB[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
