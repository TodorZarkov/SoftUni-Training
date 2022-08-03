using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex(@"\b(?<day>\d{2})([.\-/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            string dates = Console.ReadLine();
            MatchCollection validDates = rx.Matches(dates);
            foreach ( Match date in validDates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
