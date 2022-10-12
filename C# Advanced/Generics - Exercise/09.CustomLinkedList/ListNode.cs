using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public ListNode<T> PrevNode { get; set; }
        public ListNode<T> NextNode { get; set; }
        public T Value { get; set; }

        public ListNode()
        {

        }
        public ListNode(ListNode<T> prevNode, ListNode<T> nextNode, T value)
        {
            this.PrevNode = prevNode;
            this.NextNode = nextNode;
            this.Value = value;
        }
    }
}
