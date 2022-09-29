using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string brackets = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            foreach (char bracket in brackets)
            {
                if(bracket == '(' || bracket == '{' || bracket == '[')
                {
                    stack.Push(bracket);
                }
                else if (bracket == ')' || bracket == '}' || bracket == ']')
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char opBracket = stack.Pop();
                    bool isTheSameClosing = bracket - opBracket > 0 && bracket - opBracket <= 2 ? true : false;
                    if (!isTheSameClosing)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isBalanced?"YES":"NO");
        }
    }
}
