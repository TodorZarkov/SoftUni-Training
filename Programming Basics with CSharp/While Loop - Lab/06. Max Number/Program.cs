using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            if (!int.TryParse(num, out int biggest))
                return;
            while (num != "Stop")
            {
                int n = int.Parse(num);
                if (n >= biggest)
                {
                    biggest = n;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(biggest);
        }
    }
}
