using System;

public class Program
{
    public static void Main()
    {
        char a = char.Parse(Console.ReadLine());
        char b = char.Parse(Console.ReadLine());
        LettersBetween(a,b);
    }
    public static void LettersBetween(char a, char b)
    {
        if ((int)a > (int)b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
        for (int i = ((int)a) + 1; i < (int)b; i++)
        {
            Console.Write((char)i + " ");
        }
    }
}