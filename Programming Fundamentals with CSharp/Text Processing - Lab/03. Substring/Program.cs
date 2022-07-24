using System;
using System.Text;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            StringBuilder toFilter = new StringBuilder(Console.ReadLine());
            while (toFilter.ToString().Contains(toRemove))
            {
                toFilter.Replace(toRemove, "");
            }
            Console.WriteLine(toFilter);
        }
    }
}
