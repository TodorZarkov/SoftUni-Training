using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            string letter = "";

            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floors)
                    {
                        letter = "L";

                    }
                    else
                    {

                        if (i % 2 == 0)
                        {
                            letter = "O";
                        }
                        else
                        {
                            letter = "A";
                        }

                    }
                    Console.Write($"{letter}{i}{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
