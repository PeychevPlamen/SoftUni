using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public object StringBulder { get; private set; }

        public void Create(T[] list)
        {
            this.list = list.ToList();
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool HasNext() => index + 1 < list.Count;

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public void PrintAll(ListyIterator<T> array)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in array)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}