


namespace _04.BorderControl
{
    using System;
    public class Citizen : IPerson,IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
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

        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The id cannot be empty.");
                }
                id = value;
            }
        }
    }
}
