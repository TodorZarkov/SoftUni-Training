using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 5364;
            int day = 1;
            string rest = Console.ReadLine();
            while (rest != "END")
            {
                if (rest == "Yes")
                    day++;
                if (day > 5)
                    break;

                int climbed = int.Parse(Console.ReadLine());
                goal += climbed;
                if (goal >= 8848)
                    break;


                rest = Console.ReadLine();
            }
            if (goal >= 8848)
            {
                Console.WriteLine($"Goal reached for {day} days!");
            }
            else
            {
                Console.WriteLine($"Failed!");
                Console.WriteLine($"{goal}");
            }
        }
    }
}
