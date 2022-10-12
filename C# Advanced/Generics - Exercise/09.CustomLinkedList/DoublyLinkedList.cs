using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>:IEnumerable<T>
    {
        private ListNode<T> headNode;
        private ListNode<T> tailNode;
        private int count;

        public DoublyLinkedList()
        {
            count = 0;
            headNode = null;
            tailNode = null;
        }
        public int Count
        {
            get { return count; }
        }

        public void AddFirst(T element)
        {
            ListNode<T> node = new ListNode<T>(null, headNode, element);
            if (headNode != null)
            {
                headNode.PrevNode = node;
            }
            headNode = node;
            if (tailNode == null)
            {
                tailNode = headNode;
            }
            count++;
        }
        public void AddLast(T element)
        {
            ListNode<T> node = new ListNode<T>(tailNode, null, element);
            if (tailNode != null)
            {
                tailNode.NextNode = node;
            }
            tailNode = node;
            if (headNode == null)
            {
                headNode = tailNode;
            }
            count++;
        }
        public T RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T result = headNode.Value;
            if (count == 1)
            {
                headNode = null;
                tailNode = null;
            }
            else
            {
                headNode = headNode.NextNode;
                headNode.PrevNode = null;
            }
            count--;

            return result;
        }
        public T RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T result = tailNode.Value;
            if (count == 1)
            {
                headNode = null;
                tailNode = null;
            }
            else
            {
                tailNode = tailNode.PrevNode;
                tailNode.NextNode = null;
            }
            count--;
            return result;
        }
        public void ForEach(Action<T> action)
        {
            if (count != 0)
            {
                ListNode<T> currentNode = headNode;
                action(currentNode.Value);
                for (int i = 1; i < count; i++)
                {
                    currentNode = currentNode.NextNode;
                    action(currentNode.Value);
                }
            }
        }
        public T[] ToArray()
        {
            T[] result = new T[count];
            if (count != 0)
            {
                ListNode<T> currentNode = headNode;
                result[0] = currentNode.Value;
                for (int i = 1; i < count; i++)
                {
                    currentNode = currentNode.NextNode;
                    result[i] = currentNode.Value;
                }
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DLLInumerator<T>(headNode,count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DLLInumerator<T>(headNode, count);
        }
    }
}
