using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            string status = "";
            int result = 0;

            switch (op)
            {
                case '+':
                    result = n1 + n2;
                    if (result % 2 == 0)
                        status = "even";
                    else
                        status = "odd";

                    Console.WriteLine($"{n1} {op} {n2} = {result} - {status}");
                    break;
                case '-':
                    result = n1 - n2;
                    if (result % 2 == 0)
                        status = "even";
                    else
                        status = "odd";

                    Console.WriteLine($"{n1} {op} {n2} = {result} - {status}");
                    break;
                case '*':
                    result = n1 * n2;
                    if (result % 2 == 0)
                        status = "even";
                    else
                        status = "odd";

                    Console.WriteLine($"{n1} {op} {n2} = {result} - {status}");
                    break;
                case '/':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    Console.WriteLine($"{n1} {op} {n2} = {n1 * 1.0 / n2:f2}");
                    break;
                case '%':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    Console.WriteLine($"{n1} {op} {n2} = {n1%n2}");
                    break;
            }
        }
    }
}
