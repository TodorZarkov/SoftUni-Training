using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int countOfMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfMembers; i++)
            {
                string[] memberData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person member = new Person(memberData[0], int.Parse(memberData[1]));
                family.AddMember(member);
            }
            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
