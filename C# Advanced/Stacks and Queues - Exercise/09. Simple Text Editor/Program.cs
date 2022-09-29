using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> state = new Stack<string>();
            state.Push(text.ToString());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] query = Console.ReadLine().Split(' ', 2);
                string command = query[0];
                string arg = query.Length > 1 ? query[1] : "";
                switch (command)
                {
                    case "1":
                        text.Append(arg);
                        state.Push(text.ToString());
                        break;
                    case "2":
                        int count = int.Parse(arg);
                        text.Remove(text.Length - count, count);
                        state.Push(text.ToString());
                        break;
                    case "3":
                        int index = int.Parse(arg) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        state.Pop();
                        text.Clear();
                        text.Append(state.Peek());
                        break;
                }
            }
        }
    }
}
