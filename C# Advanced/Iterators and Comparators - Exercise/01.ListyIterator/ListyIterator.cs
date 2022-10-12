using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }
}
