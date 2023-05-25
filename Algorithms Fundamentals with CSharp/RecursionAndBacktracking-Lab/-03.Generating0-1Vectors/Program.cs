namespace _03.Generating0_1Vectors
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int bits = int.Parse(Console.ReadLine());

            int[] vector = new int[bits];

            GenerateVector(vector);
        }

        private static void GenerateVector(int[] vector, int index = 0)
        {

            for (int i = 0; i < 2; i++)
            {
                if (index >= vector.Length)
                {
                    Console.WriteLine(string.Join("", vector));
                    return;
                }
                vector[index] = i;
                GenerateVector(vector, index + 1);
            }
        }
    }
}