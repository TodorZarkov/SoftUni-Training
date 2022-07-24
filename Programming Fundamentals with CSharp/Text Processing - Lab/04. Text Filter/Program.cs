using System;
using System.Text;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            StringBuilder text = new StringBuilder(Console.ReadLine());
            foreach (string banWord in banList)
            {
                string asterisk = new string('*', banWord.Length);
                text.Replace(banWord, asterisk);
            }
            Console.WriteLine(text);
        }
    }
}
