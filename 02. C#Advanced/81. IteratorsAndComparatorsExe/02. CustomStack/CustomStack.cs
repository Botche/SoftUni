using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class CustomStack<T>:IEnumerable<T>
    {
        private List<T> customStack;
        private int currentIndex;
        public CustomStack()
        {
            customStack = new List<T>();
            currentIndex = -1;
        }

        public void Push(T[] items)
        {
            customStack.AddRange(items);
            currentIndex += items.Length;
        }

        public T Pop()
        {
            if (currentIndex==-1)
            {
                throw new InvalidOperationException("No elements");
            }

            var elementToPop = customStack[currentIndex];

            customStack.RemoveAt(currentIndex);
            currentIndex--;

            return elementToPop;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = currentIndex; i >= 0; i--)
            {
                yield return customStack[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
