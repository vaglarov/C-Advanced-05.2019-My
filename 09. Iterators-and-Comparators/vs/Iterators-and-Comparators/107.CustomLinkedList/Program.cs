using System;

namespace _107.CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddLast("a");
            list.AddLast("b");
            list.AddLast("c");
            list.AddLast("d");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
