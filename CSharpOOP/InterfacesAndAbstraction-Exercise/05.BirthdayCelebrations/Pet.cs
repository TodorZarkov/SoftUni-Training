
namespace _05.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public class Pet : IBirthable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
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

        public string Birthdate
        {
            get { return birthdate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birthdate cannot be empty.");
                }
                birthdate = value;
            }
        }
    }
}
