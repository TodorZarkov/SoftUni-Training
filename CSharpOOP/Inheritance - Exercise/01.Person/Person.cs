using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public virtual int Age 
        {
            get { return age; }
            set 
            {
                if(value < 0)
                {
                    // throw new ArgumentOutOfRangeException("The age cannot be negative!");
                    age = 0;
                }
                age = value;
            } 
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");

            return sb.ToString();
        }
    }
}
