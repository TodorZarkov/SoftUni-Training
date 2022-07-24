using System;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            foreach (string name in names)
            {
                bool isValidName = true;
                if (name.Length >= 3 && name.Length <= 16)
                {
                    foreach (char symbol in name)
                    {
                        if (!Char.IsLetterOrDigit(symbol) && !(symbol == '-') && !(symbol == '_'))
                        {
                            isValidName = false;
                            break;
                        }
                    }
                    if (isValidName)
                        Console.WriteLine(name);
                }
            }
        }
    }
}
