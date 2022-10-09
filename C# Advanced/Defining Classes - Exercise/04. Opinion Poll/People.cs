using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class People
    {
        private List<Person> people;
        public People()
        {
            this.people = new List<Person>();
        }
        public void AddPerson(Person member)
        {
            this.people.Add(member);
        }

        public List<Person> GetAbove30()
        {
            return this.people.Where(p=>p.Age>30).OrderBy(p=>p.Name).ToList();
        }
    }
}
