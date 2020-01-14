using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T>: IEnumerable<T>
    {
        private List<T> listy;
        private int currentIndex;

        public ListyIterator(List<T> elements)
        {
            listy = elements;
            currentIndex = 0;
        }

        public bool Move()
        {
            bool isValid = false;
            if (currentIndex < listy.Count - 1)
            {
                currentIndex++;
                isValid = true;
            }
            return isValid;
        }

        public bool HasNext()
        {
            bool hasNext = false;

            if (currentIndex < listy.Count - 1)
            {
                hasNext = true;
            }

            return hasNext;
        }

        public void Print()
        {
            if (listy.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(listy[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in listy)
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
