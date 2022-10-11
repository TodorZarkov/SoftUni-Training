using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _06.GenericCountMethodDouble
{
    public class Box<Type> where Type:IComparable
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

        public int Count(List<Type> items, Type token)
        {
            int result = 0;
            foreach (var item in items)
            {
                if (item.CompareTo(token)==1)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
