
namespace _05.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Xml.Linq;
    public class Rebel : IPerson, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;



        private Rebel()
        {
            Food = 0;
        }
        public Rebel(string name, int age, string group) : this()
        {
            Name = name;
            Age = age;
            Group = group;
        }



        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name must not be empty");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive.");
                }
                age = value;
            }
        }

        public string Group
        {
            get { return group; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The group cannot be empty.");
                }

                group = value;
            }
        }

        public int Food
        {
            get => food;
            private set
            {
                food = value;
            }
        }



        public void BuyFood()
        {
            Food += 5;
        }

        
    }
}
