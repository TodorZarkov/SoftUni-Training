using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rx = @"\+359 2 [0-9]{3,3} [0-9]{4,4}\b|\+359-2-[0-9]{3,3}-[0-9]{4,4}\b";
            string numbers = Console.ReadLine();
            MatchCollection matchedNumbers = Regex.Matches(numbers, rx);

            Console.WriteLine(string.Join(", ", matchedNumbers)); 
            
        }
    }
}
