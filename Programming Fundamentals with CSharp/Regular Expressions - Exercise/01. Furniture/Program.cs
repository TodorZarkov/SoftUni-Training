using System;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex(@"(^>>(?<name>\w+)<<(?<price>\d+\.{0,1}\d+)!(?<quantity>\d+)\b)");
            string line = Console.ReadLine();
            while (line != "Purchase")
            {
                MatchCollection matchedLines = rx.Matches(line);

                line = Console.ReadLine();
            }
        }
    }
}
