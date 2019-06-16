using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> listItems;
        public Box()
        {
            listItems = new List<T>();
        }

        internal IEnumerable<object> toList()
        {
            throw new NotImplementedException();
        }

        public int Count => listItems.Count;

        public void Add(T item)
        {
            listItems.Add(item);
        }
        public T Remove()
        {
            if (Count > 0)
            {
                var element = listItems.LastOrDefault();
                listItems.Remove(element);
                return element;
            }
            throw new InvalidOperationException("The collection is empty!!!");
        }
    }
}
