using System;

namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int msgLength = int.Parse(Console.ReadLine());
            for(int i = 0; i < msgLength; i++)
            {
                string number = Console.ReadLine();
                int len = number.Length;
                int digits = int.Parse(number);
                int mainDigit = digits % 10;
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int index = offset + len + 96;
                if (mainDigit == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write((char)index);
                }
            }
        }
    }
}
