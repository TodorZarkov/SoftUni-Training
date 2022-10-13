using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
                sortedSet.Add(person);
                hashSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
