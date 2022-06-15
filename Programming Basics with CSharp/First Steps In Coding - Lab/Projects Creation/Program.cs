using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());

            int totalTime = projects * 3;

            Console.WriteLine($"The architect {name} will need {totalTime} hours to complete {projects} project/s.");
        }
    }
}
