using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        private int count;
        public ListyIterator()
        {
            count = 0;
            index = 0;
            elements = new List<T>();

        }
        public ListyIterator(params T[] inputElements)
        {
            count = inputElements.Length;
            index = 0;
            elements = new List<T>(inputElements);
        }

        public bool Move()
        {
            if (index + 1 >= count)
            {
                return false;
            }
            index++;
            return true;
        }
        public bool HasNext()
        {
            if (index + 1 >= count)
            {
                return false;
            }
            return true;
        }
        public void Print()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void PrintAll()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item);
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
