using System;

public class Program
{
    public static void Main()
    {
        int lines = 3;
        int[] a = new int[lines];
        for (int i = 0; i < lines; i++)
        {
            a[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(Smallest(a));
        
    }

    public static int Smallest(int[] a)
    {
        int sml = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (sml > a[i])
            {
                sml = a[i];
            }
        }
        return sml;
    }
}