using System;

namespace _06.BalancedBracks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int opened = 0;
            int closed = 0;


            for (int i = 0; i < lines; i++)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "(")
                {
                    opened++;
                }
                else if (inputLine == ")")
                {
                    closed++;
                }
                if ((int)Math.Abs(opened - closed) > 1 || opened - closed < 0)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
            if (opened - closed == 0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
