using System;
using System.Globalization;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(3);
            dll.AddLast(4);
            dll.AddLast(5);
            dll.AddLast(6);
            dll.AddLast(7);
            dll.AddLast(8);
            dll.AddLast(9);
            dll.AddLast(10);
            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }
        }
    }
}
