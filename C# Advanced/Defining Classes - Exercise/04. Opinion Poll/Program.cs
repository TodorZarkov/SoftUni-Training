using System;

namespace OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            People people = new People();
            int countLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countLines; i++)
            {
                string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personData[0], int.Parse(personData[1]));
                people.AddPerson(person);
            }
            people.GetAbove30().ForEach(p =>
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            });
        }
    }
}
