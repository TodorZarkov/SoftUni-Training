using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private string type = "Kitten";
        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }
        public override string Gender { get => base.Gender;}

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
