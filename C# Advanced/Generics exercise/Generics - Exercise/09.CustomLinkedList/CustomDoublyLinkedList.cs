using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
       public class ListNode
        {
             public ListNode(T value)
            {
                Value = value;
            }
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

        }
        private ListNode head;
        private ListNode tail;

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            ListNode newNode = new ListNode(element);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.NextNode = head;
                head.PreviousNode = newNode;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            ListNode newNode = new ListNode(element);

            if (Count == 0)
            {
                tail = newNode;
                head = newNode;
            }
            else
            {
                newNode.PreviousNode = tail;
                tail.NextNode = newNode;
                tail = newNode;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            ListNode currenthead = head;
            head = head.NextNode;

            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return currenthead.Value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            ListNode currenttail = tail;
            tail = tail.PreviousNode;

            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return currenttail.Value;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currentNode = head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            List<T> myList = new List<T>();

            ListNode currentNode = head;

            while (currentNode != null)
            {
                myList.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            return myList.ToArray();
        }

    }
}