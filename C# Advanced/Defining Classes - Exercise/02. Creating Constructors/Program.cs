using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "Pesho",
                Age = 30
            };

            Person p2 = new Person(5);

            Person p3 = new Person();
            Console.WriteLine(person.Name + " " + person.Age);
            Console.WriteLine(p2.Name + " " + p2.Age);
            Console.WriteLine(p3.Name + " " + p3.Age);
        }
    }
}
