using System;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            string[] intNumbers = Console.ReadLine().Split(separator);
            int offset = int.Parse(Console.ReadLine());
            string[] rotated = new string[intNumbers.Length];
            for (int i = 0; i < intNumbers.Length - offset; i++)
            {
                rotated[i] = intNumbers[i + offset];
            }
            for (int i = intNumbers.Length - offset; i < intNumbers.Length; i++)
            {
                rotated[i] = intNumbers[i - (offset + 1)];
            }
            Console.WriteLine(string.Join(separator,rotated));
        }
    }
}
