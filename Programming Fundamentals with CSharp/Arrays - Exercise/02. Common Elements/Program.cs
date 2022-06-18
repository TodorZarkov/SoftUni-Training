using System;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            string[] firstLine = Console.ReadLine().Split(separator);
            string[] secondLine = Console.ReadLine().Split(separator);
            string output = string.Empty;
            for (int i = 0; i < secondLine.Length; i++)
            {
                for (int j = 0; j < firstLine.Length; j++)
                {
                    if (secondLine[i] == firstLine[j])
                    {
                        output +=  firstLine[j] + " ";
                    }
                }
            }
            Console.WriteLine(output.TrimEnd());
        }
    }
}
