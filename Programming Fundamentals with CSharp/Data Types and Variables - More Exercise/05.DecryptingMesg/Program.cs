using System;

namespace _05.DecryptingMesg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                char gryph = char.Parse(Console.ReadLine());
                message += (char)((int)gryph + key);
            }
            Console.WriteLine(message);
        }
    }
}
