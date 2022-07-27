using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            // {



            string inputNumber = Console.ReadLine();
            byte digit = byte.Parse(Console.ReadLine());
            if (digit == 0)
            {
                Console.WriteLine(0);
                return;
            }
            byte[] bigNumber = new byte[inputNumber.Length + 1];
            int strIndex = inputNumber.Length - 1;
            byte reminder = 0;
            for (int i = 0; i < bigNumber.Length; i++)
            {
                if (strIndex >= 0)
                {
                    bigNumber[i] = (byte)((reminder + (inputNumber[strIndex] - 48) * digit) % 10);
                    reminder = (byte)((reminder + (inputNumber[strIndex] - 48) * digit) / 10);
                    strIndex--;
                }
                else
                {
                    bigNumber[i] = reminder;
                }
            }
            int len = bigNumber.Length;
            if (bigNumber.Last() == 0)
            {
                len = bigNumber.Length - 1;
            }
            for (int i = len - 1; i >= 0; i--)
            {
                Console.Write(bigNumber[i]);
            }
        }
    }
}
//}
