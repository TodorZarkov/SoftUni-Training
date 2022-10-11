using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                Box<string> box = new Box<string>(line);
                Console.WriteLine(box);
                
            }
        }
    }
}
