using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DLLInumerator<T> : IEnumerator<T>
    {
        private ListNode<T> currentNode;
        private int count;
        private int index;
        public DLLInumerator(ListNode<T> headNode, int count)
        {

            currentNode = headNode;
            this.count = count;
            index = 0;
        }
        public T Current => currentNode.Value;

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            index = 0;
        }

        public bool MoveNext()
        {

            bool result = false;
            if (++index <= count)
            {
               if(index!=1)
                    currentNode = currentNode.NextNode;
                    result = true;
                              
                
            }
            return result;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
