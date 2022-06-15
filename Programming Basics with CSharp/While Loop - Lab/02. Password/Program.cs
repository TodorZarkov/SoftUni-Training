using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            string text = Console.ReadLine();

            while (pass != text)
            {
                text = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {user}!");
        }
    }
}
  