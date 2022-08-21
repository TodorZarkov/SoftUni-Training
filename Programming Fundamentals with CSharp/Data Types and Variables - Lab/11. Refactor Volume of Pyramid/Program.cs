using System;

public class Program
{
	public static void Main()
	{
		Console.Write("Length: ");
		double length = double.Parse(Console.ReadLine());

		Console.Write("Width: ");
		double width = double.Parse(Console.ReadLine());

		Console.Write("Height: ");
		double hight = double.Parse(Console.ReadLine());

		double volume = (length * width * hight) / 3;
		Console.Write($"Pyramid Volume: {volume:f2}");
	}
}