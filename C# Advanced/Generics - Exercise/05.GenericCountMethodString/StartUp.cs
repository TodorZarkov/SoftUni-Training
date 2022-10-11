using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(line);
            }

            string toMatch = Console.ReadLine();
            Console.WriteLine(box.Count(box.Items,toMatch));
        }
    }
}
