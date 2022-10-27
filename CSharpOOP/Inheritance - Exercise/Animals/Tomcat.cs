using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Tomcat : Cat
    {
        private string type = "Tomcat";
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }
        public override string Gender { get => base.Gender;}
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
