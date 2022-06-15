using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                k = int.Parse(Console.ReadLine());
                if (k < 200)
                {
                    p1++;
                }
                else if (k >= 200 && k <= 399)
                {
                    p2++;
                }
                else if (k >= 400 && k <= 599)
                {
                    p3++;
                }
                else if (k >= 600 && k <= 799)
                {
                    p4++;
                }
                else if (k >= 800)
                {
                    p5++;
                }
            }
            
            Console.WriteLine($"{100.0 * p1 / n:f2}%");
            Console.WriteLine($"{100.0 * p2 / n:f2}%");
            Console.WriteLine($"{100.0 * p3 / n:f2}%");
            Console.WriteLine($"{100.0 * p4 / n:f2}%");
            Console.WriteLine($"{100.0 * p5 / n:f2}%");
        }
    }
}
