using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = "";
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            string tryPassword = Console.ReadLine();
            int failedTryes = 0;
            while (tryPassword != password)
            {
                failedTryes++;
                if (failedTryes == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                tryPassword = Console.ReadLine();
            }
            Console.WriteLine($"User {userName} logged in.");
        }
    }
}
