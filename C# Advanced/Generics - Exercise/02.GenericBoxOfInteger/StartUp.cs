using System;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int line = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(line);
                Console.WriteLine(box);

            }
        }
    }
}
