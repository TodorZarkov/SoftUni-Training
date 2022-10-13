using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    internal class Stack<T> : IEnumerable<T>
    {
        private Node<T> topNode;
        private int count;
        public Stack()
        {
            topNode = null;
            count = 0;
        }
        public int Count
        {
            get { return count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = new Node<T>();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    current = topNode;
                    yield return topNode.Value;
                }
                else
                {
                    current = current.PrevNode;
                    yield return current.Value;
                }
            }
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T result = topNode.Value;
            if (count == 1)
            {
                topNode = null;
            }
            else
            {
                topNode = topNode.PrevNode;
            }
            count--;
            return result;
        }
        public void Push(T element)
        {
            if (count == 0)
            {
                topNode = new Node<T>(null, element);
            }
            else
            {
                Node<T> node = new Node<T>(topNode, element);
                topNode = node;
            }
            count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
