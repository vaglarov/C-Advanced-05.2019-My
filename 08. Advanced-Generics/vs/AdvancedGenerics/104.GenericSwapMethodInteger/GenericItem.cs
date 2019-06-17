using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _104.GenericSwapMethodInteger
{
    public class GenericItem<T> 
    {
      
        private List<T> elements;
        public GenericItem()
        {
            elements = new List<T>();
        }
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
