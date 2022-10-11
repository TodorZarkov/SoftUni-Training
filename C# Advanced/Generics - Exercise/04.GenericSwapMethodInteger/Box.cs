using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<Type>
    {
        public Box()
        {
            Items = new List<Type>();
        }

        public List<Type> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Items.ForEach(item => sb.AppendLine($"{item.GetType()}: {item}"));
            return sb.ToString();
        }

        public void Swap(int n,int m)
        {
            Type temp = Items[n];
            Items[n] = Items[m];
            Items[m] = temp;
        }
    }
}
