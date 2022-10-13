using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public override int GetHashCode()
        {
            return Name.ToLower().ToCharArray().Select(x => (int)x).Sum() + Age;
        }
        public override bool Equals(object obj)
        {
            Person other = (Person)obj;
            bool isEqual = false;
            string thisNameLower = this.Name.ToLower();
            string otherNameLower = other.Name.ToLower();
            if (thisNameLower.CompareTo(otherNameLower) == 0 && this.Age == other.Age)
            {
                isEqual = true;
            }
            return isEqual;
        }
        public int CompareTo(Person other)
        {
            string thisNameLower = this.Name.ToLower();
            string otherNameLower = other.Name.ToLower();
            if (thisNameLower.CompareTo(otherNameLower) ==0)
            {
                return this.Age - other.Age;
            }
            else
            {
                return thisNameLower.CompareTo(otherNameLower);
            }
        }
    }
}
