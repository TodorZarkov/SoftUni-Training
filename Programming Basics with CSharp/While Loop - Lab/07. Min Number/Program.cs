using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            if (!int.TryParse(num, out int lowest))
                return;
            while (num != "Stop")
            {
                int n = int.Parse(num);
                if (n <= lowest)
                {
                    lowest = n;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(lowest);
        }
    }
}
