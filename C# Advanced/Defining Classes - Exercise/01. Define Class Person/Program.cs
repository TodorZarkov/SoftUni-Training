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
                Age = 29
            };
            Console.WriteLine(person.Name + " " + person.Age);
        }
    }
}
