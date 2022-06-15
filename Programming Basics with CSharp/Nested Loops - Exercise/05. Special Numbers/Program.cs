using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //1111 до 9999. range of special numbers!!!

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;
                string digits = i.ToString();
                for (int j = 0; j < 4; j++)
                {
                    int digit = int.Parse(digits[j].ToString());
                    if (digit == 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    if (n %  digit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }
                if (isSpecial)
                    Console.Write(i + " ");
            }
        }
    }
}
