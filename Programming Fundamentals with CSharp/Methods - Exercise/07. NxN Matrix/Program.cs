using System;
					
public class Program
{
	public static void Main()
	{
		int filler = int.Parse(Console.ReadLine());
        Matrix(filler);
	}

    //matrix filler x filler filled with filler
    public static void Matrix(int filler)
    {
        for (int i = 0; i < filler; i++)
        {
            for (int j = 0; j < filler; j++)
            {
                Console.Write(filler + " ");
            }
            System.Console.WriteLine();
        }
    }
}