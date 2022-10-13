using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (data[0] != "END")
            {
                Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                people.Add(person);

                data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            int index = int.Parse(Console.ReadLine())-1;

            int numberOfEqual = 0;
            foreach (var person in people)
            {
                if (people[index].CompareTo(person) == 0)
                {
                    numberOfEqual++;
                }
            }
            if (numberOfEqual == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{numberOfEqual} {people.Count-numberOfEqual} {people.Count}");
            }
        }
    }
}
