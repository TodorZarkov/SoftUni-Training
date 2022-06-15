using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            if (q > 0)
            {
                
                int n = int.Parse(Console.ReadLine());
                int biggest = n;
                int sum = n;
                for (int i = 0; i < q - 1; i++)
                {
                    n = int.Parse(Console.ReadLine());
                    if (n > biggest)
                    {
                        biggest = n;
                    }
                    sum += n;
                    
                }
                int diff = sum - biggest;
                if (diff == biggest)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine($"Sum = { Math.Abs(biggest)}");
                }
                else
                {
                    Console.WriteLine("No");
                    Console.WriteLine($"Diff = {Math.Abs(diff - biggest)}");
                }
            }
        }
    }
}
