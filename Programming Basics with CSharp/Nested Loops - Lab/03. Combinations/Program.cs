using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = 0;
            int y = 0;
            int z = 0;
            int counter = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        if(i+j+k == n)
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
            
        }
    }
}
