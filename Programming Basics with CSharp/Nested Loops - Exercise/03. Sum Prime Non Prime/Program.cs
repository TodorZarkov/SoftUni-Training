using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            int num = 0;
            int prime = 0;
            int noPrime = 0;

            while (entry != "stop")
            {
                num = int.Parse(entry);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    entry = Console.ReadLine();
                    continue;
                }

                bool isPrime = true;
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    prime += num;
                }
                else
                {
                    noPrime += num;
                }


                entry = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {prime}");
            Console.WriteLine($"Sum of all non prime numbers is: {noPrime}");
        }
    }
}
