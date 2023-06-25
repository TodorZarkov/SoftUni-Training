namespace _04.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static string[] places;
        private static bool[] locked;

        private static List<string> freePlaces;


        static void Main(string[] args)
        {
            freePlaces = Console.ReadLine()
                .Split(", ")
                .ToList();
            places = new string[freePlaces.Count];
            locked = new bool[freePlaces.Count];

            string line = Console.ReadLine();
            while (line != "generate")
            {
                string[] command = line.Split(" - ").ToArray();
                string name = command[0];
                int place = int.Parse(command[1]) - 1;
                places[place] = name;
                locked[place] = true;
                freePlaces.Remove(name);

                line = Console.ReadLine();
            }

            Permute(0);

        }

        private static void Permute(int index)
        {
            if (index > freePlaces.Count)
            {
                Print();
                return;
            }
            Permute(index + 1);
            for (int i = index + 1; i < freePlaces.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }

        }

        private static void Print()
        {
            int freeIdx = 0;
            for (int i = 0; i < locked.Length; i++)
            {
                if (!locked[i])
                {
                    places[i] = freePlaces[freeIdx];
                    freeIdx++;
                }
            }
            Console.WriteLine(string.Join(" ", places));
        }

        private static void Swap(int first, int second)
        {
            (freePlaces[first], freePlaces[second]) =
                (freePlaces[second], freePlaces[first]);
        }
    }
}
