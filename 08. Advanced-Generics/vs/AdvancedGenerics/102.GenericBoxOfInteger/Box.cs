namespace _102.GenericBoxOfInteger
{
using System;
using System.Collections.Generic;
using System.Text;
    public class Box<T>
    {
        private T value;
        public Box(T element)
        {
            Element = element;
        }
        public T Element { get; set; }
        public override string ToString()
        {
            return $"{Element.GetType()}: {Element}";
        }
    }
}
