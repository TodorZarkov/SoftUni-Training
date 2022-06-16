using System;

namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int charSum = 0;
            for (int i = 0; i < range; i++)
            {
                charSum += (int)char.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}
