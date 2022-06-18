using System;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            int lines = int.Parse(Console.ReadLine());
            string[] firstLineOut = new string[lines];
            string[] secondLineOut = new string[lines];
            string[] line = new string[2];

            for (int i = 0; i < lines; i++)
            {
                line = Console.ReadLine().Split(separator);
                firstLineOut[i] = line[i % 2];
                secondLineOut[i] = line[(i+1) % 2 ];
            }
            Console.WriteLine(String.Join(separator,firstLineOut));
            Console.WriteLine(String.Join(separator,secondLineOut));

        }
    }
}
