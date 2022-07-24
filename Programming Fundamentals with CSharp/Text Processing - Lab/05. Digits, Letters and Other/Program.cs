using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder otherSymbols = new StringBuilder();
            foreach (char symbol in text)
            {
                if (symbol >= '0' && symbol <= '9')
                {
                    digits.Append(symbol);
                }
                else if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                {
                    letters.Append(symbol);
                }
                else
                {
                    otherSymbols.Append(symbol);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherSymbols);

        }
    }
}
