using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box;

        public int Count { get => BoxOfT.Count; }
        public List<T> BoxOfT { get; set; }

        public Box()
        {
            BoxOfT = new List<T>();
        }
        public void Add(T element)
        {
            BoxOfT.Add(element);
        }

        public T Remove()
        {
            var lastElement = BoxOfT.LastOrDefault();

            if (BoxOfT.Count!=0)
            {
                BoxOfT.RemoveAt(Count - 1);
            }
            else
            {
                throw new InvalidOperationException("Box is empty");
            }

            return lastElement;
        }
    }
}
