using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _106.GenericCountMethodDoubles
{
    public class GenericItem<T> 
        where T:IComparable<T>
    {
      
        private List<T> elements;
        public GenericItem()
        {
            elements = new List<T>();
        }
        public int CountGreater { get;private set; }
        public void Add(T element)
        {
            elements.Add(element);
        }
        public void Swap(int firstIndex,int secondIndex)
        {
            var tempElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = tempElement;
        }

        public void Compare(T element)
        {
            foreach (var item in elements)
            {
                if (item.CompareTo(element) >0)
                {
                    this.CountGreater++;
                }
            }
        }
        public int Count()
        {
            return elements.Count;
        }

        public void PrintForeach()
        {
            foreach (var item in elements)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        
    }
}
