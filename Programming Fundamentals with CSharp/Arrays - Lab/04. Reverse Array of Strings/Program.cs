using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()));
        }
    }
}
