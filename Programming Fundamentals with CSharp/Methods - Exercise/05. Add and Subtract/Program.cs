using System;
					
public class Program
{
	public static void Main()
	{
		int firstNum = int.Parse(Console.ReadLine());
		int secondNum = int.Parse(Console.ReadLine());
		int thirdNum = int.Parse(Console.ReadLine());
        System.Console.WriteLine(Subtract(Add(firstNum,secondNum),thirdNum));
	}
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}