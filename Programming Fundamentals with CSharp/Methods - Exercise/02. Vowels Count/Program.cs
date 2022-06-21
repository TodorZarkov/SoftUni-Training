using System;
					
public class Program
{
	public static void Main()
	{
		NumberOfVowels(Console.ReadLine());
	}
    //The vowels in English are a, e, i, o, u, and sometimes y.
    //PRINTS the number of vowels.
    public static void NumberOfVowels(string line)
    {
        char[] symbols = {'a', 'e', 'i', 'o', 'u'};
        int numberOfVowels = 0;
        line = line.ToLower();
        foreach (char item in line)
        {
            foreach (char symbol in symbols)
            {
                if (item == symbol)
                {
                    numberOfVowels++;
                }
            }
        }
        System.Console.WriteLine(numberOfVowels);
    }

}