using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person:IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name == other.Name&&
                this.Age == other.Age&&
                this.Town== other.Town)
            {
                return 0;
            }
            return -1;
        }
    }
}
