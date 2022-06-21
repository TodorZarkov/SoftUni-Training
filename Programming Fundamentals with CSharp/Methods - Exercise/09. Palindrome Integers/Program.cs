using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(IsPalindrom(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }
        static bool IsPalindrom (string line)
        {
            char[] frw= line.ToCharArray();
            char[] bcw = new char[frw.Length];
            frw.CopyTo(bcw, 0);
            Array.Reverse(bcw);   
            
            return string.Join(' ',frw) == string.Join(' ',bcw);
        }
    }
}
