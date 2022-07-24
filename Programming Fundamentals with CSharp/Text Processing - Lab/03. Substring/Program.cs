using System;
using System.Text;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            string toFilter = Console.ReadLine();
            while (toFilter.IndexOf(toRemove)!= -1)
            {
                toFilter = toFilter.Remove(toFilter.IndexOf(toRemove), toRemove.Length);
            }
            Console.WriteLine(toFilter);
        }
    }
}
