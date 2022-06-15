using System;

namespace _02._Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string weather = Console.ReadLine();
            //sunny, cloudy, rainy

            if (weather == "sunny")
            {
                Console.WriteLine("go for a wallk");
            }
            else if(weather == "cloudy")
            {
                Console.WriteLine("take an umbrella");
            }
            else if(weather == "rainy")
            {
                Console.WriteLine("stay home");
            }
        }
    }
}
