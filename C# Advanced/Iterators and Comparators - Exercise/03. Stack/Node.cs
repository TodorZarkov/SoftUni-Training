using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    internal class Node<T>
    {
        public Node()
        {

        }
        public Node(Node<T> prevNode, T value)
        {
            PrevNode = prevNode;
            Value = value;
        }

        public Node<T> PrevNode { get; set; }
        public T Value { get; set; }
    }
}
