using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T value;

        public Box (T item)
        {
            value = item;
        }

        public override string ToString()
        {
            return $"{value.GetType().FullName}: {value}";
        }
    }
}
