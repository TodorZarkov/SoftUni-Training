using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] personData = line.Split(' ');
                string personName = personData[0];
                string personID = personData[1];
                int personAge = int.Parse(personData[2]);

                Person personToUpdate = people.FirstOrDefault(p => p.ID == personID);
                if (personToUpdate != null)
                {
                    personToUpdate.Age = personAge;
                    personToUpdate.Name = personName;
                }
                else
                {
                    Person person = new Person(personName, personID, personAge);
                    people.Add(person);
                }

                line = Console.ReadLine();
            }

            people.OrderBy(p => p.Age).ToList().ForEach(x => Console.WriteLine(x));
        }
    }

    class Person
    {
        public Person(string name, string iD, int age)
        {
            this.Name = name;
            this.ID = iD;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
