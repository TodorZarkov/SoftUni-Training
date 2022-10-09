using System;


namespace DefiningClasses
{
    internal class Person
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}
