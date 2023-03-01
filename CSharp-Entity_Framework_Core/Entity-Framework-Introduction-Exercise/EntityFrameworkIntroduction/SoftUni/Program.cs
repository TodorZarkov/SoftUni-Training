namespace SoftUni;

using Data;
public class Program
{
    private static void Main(string[] args)
    {
        SoftUniContext ctx = new SoftUniContext();
        Console.WriteLine("Connected!");
    }
}