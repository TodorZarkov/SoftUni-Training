using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;
        private string name;
        private string gender;
        
        public Animal(string name, int age, string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }

      
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public virtual string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException ("Invalid input!");
                }
                gender = value;
            } 
        }

        public virtual string ProduceSound()
        {
            return "Rrrrrrr";
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            string type = this.ToString();
            type = type.StartsWith("Animals.") ? type.Remove(0, 8) : type;
            sb.AppendLine($"{type}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append($"{ProduceSound()}");
            return sb.ToString();
        }
    }
}
