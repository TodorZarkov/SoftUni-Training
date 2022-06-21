using System;

public class Program
{
    public static void Main()
    {
        System.Console.WriteLine(MidElement(Console.ReadLine()));
    }
    public static string MidElement(string line)
    {
        int ind = line.Length / 2;
        if (line.Length % 2 == 0)
        {
            return line[ind - 1] + "" + line[ind];
        }
        else
        {
            return "" + line[ind];
        }
    }
}