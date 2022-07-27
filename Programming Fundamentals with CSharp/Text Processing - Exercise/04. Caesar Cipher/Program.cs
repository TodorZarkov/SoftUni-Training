using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder encriptedText = new StringBuilder();
            const int offset = 3;
            for (int i = 0; i < text.Length; i++)
            {
                encriptedText.Append((char)((int)text[i] + offset));
            }
            Console.WriteLine(encriptedText);
        }
    }
}
