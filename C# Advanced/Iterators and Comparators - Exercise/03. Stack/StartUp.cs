using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string[] command = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Push":
                        command[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList().ForEach(stack.Push);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
                command = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


        }
    }
}
