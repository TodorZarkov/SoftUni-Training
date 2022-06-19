using System;

namespace _04._Array_Rotation
{
    internal class Program
    {
        
        // arr.len time consuming algorithm
        // 2*arr.len memory consuming algorithm
        static void Main(string[] args)
        {
            char separator = ' ';
            string[] intNumbers = Console.ReadLine().Split(separator);
            int offset = int.Parse(Console.ReadLine());
            string[] rotated = new string[intNumbers.Length];

            while(offset >= intNumbers.Length)
            {
                offset -= intNumbers.Length;
            }

            for (int i = 0; i < intNumbers.Length - offset; i++)
            {
                rotated[i] = intNumbers[i + offset];
            }
            for (int i = intNumbers.Length - offset; i < intNumbers.Length; i++)
            {
                rotated[i] = intNumbers[i - (intNumbers.Length - offset)];
            }
            Console.WriteLine(string.Join(separator,rotated));
        }
    }
}
