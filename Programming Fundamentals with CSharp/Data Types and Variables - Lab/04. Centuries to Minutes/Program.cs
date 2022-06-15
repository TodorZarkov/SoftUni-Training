using System;

namespace _04._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to enter an integer number of centuries and convert it to years, days, hours and minutes.
            //· Assume that a year has 365.2422 days on averag
            int centuies = int.Parse(Console.ReadLine());
            int years = centuies * 100;
            int days = (int) (years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{centuies} centuries = {years} years = {days:f0} days = {hours:f0} hours = {minutes:f0} minutes");
        }
    }
}
