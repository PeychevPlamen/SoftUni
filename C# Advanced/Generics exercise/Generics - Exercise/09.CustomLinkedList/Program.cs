using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> myList = new DoublyLinkedList<string>();

            for (int i = 1; i <= 10; i++)
            {
                myList.AddFirst(i + "");
            }

            for (int m = 1; m <= 10; m++)
            {
                myList.AddLast(m + "");
            }

            Console.WriteLine(myList.RemoveFirst());

            Console.WriteLine(myList.RemoveLast());

            Console.WriteLine(myList.RemoveLast());

            myList.AddFirst(1001 + "");
            myList.AddLast(1001 + "");

            Console.WriteLine(string.Join(" ", myList.ToArray()));
            Console.WriteLine(myList);
            Console.WriteLine(myList.ToArray());

        }
    }
}