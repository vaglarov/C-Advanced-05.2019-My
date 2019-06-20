using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _102.Collection
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (this.index < this.list.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.list[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
