using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<Type>
    {
        public Box(Type variale)
        {
            Variale = variale;
        }

        public Type Variale { get; set; }

        public override string ToString()
        {
            return $"{Variale.GetType()}: {Variale}";
        }
    }
}
