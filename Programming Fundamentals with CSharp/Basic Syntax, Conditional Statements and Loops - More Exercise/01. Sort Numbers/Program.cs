using System;

namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a <= b)
            {
                if (a <= c)
                {
                    if (b <= c)
                    {
                        Console.WriteLine(c);
                        Console.WriteLine(b);
                        Console.WriteLine(a);
                    }
                    else
                    {
                        Console.WriteLine(b);
                        Console.WriteLine(c);
                        Console.WriteLine(a);
                    }
                }
                else
                {
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }
            }
            else
            {
                if (a<=c)
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }
                else
                {
                    if (c<=b)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                        Console.WriteLine(c);
                    }
                    else
                    {
                        Console.WriteLine(a);
                        Console.WriteLine(c);
                        Console.WriteLine(b);
                    }
                }
                
            }

        }
    }
}
