using System;

namespace _01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {

                if (int.TryParse(input, out int inputInt))
                {
                    Console.WriteLine($"{inputInt} is integer type");
                }
                else if (double.TryParse(input, out double inputFloat))
                {
                    Console.WriteLine($"{inputFloat} is floating point type");
                }
                else if (char.TryParse(input, out char inputChar))
                {
                    Console.WriteLine($"{inputChar} is character type");
                }
                else if (bool.TryParse(input, out bool inputBool))
                {
                    Console.WriteLine($"{inputBool} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
