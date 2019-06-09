using System;
using System.Collections.Generic;
using System.Text;

namespace _02._CustomStack
{
    class CustomStack
    {
        private const int capacity = 4;
        private int[] innerArr;

        /// <summary>
        /// Returns count of elements in CustomStack
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates CustomStack
        /// </summary>
        public CustomStack()
        {
            innerArr = new int[capacity];
        }

        /// <summary>
        /// Adds element at the end of structure
        /// </summary>
        /// <param name="element">Must be integer</param>
        public void Add(int element)
        {
            CheckSizeOfArray();

            innerArr[Count] = element;

            Count++;
        }
        /// <summary>
        /// Pops last element
        /// </summary>
        /// <returns>Last element from collection</returns>
        public int Pop()
        {
            CheckForEmptyStack();

            Count--;

            int poppedElement = innerArr[Count];

            innerArr[Count] = default;

            return poppedElement;
        }
        /// <summary>
        /// Show last element
        /// </summary>
        /// <returns>Return value of last element</returns>
        public int Peek()
        {
            CheckForEmptyStack();

            var peekElement = innerArr[Count - 1];

            return peekElement;
        }
        /// <summary>
        /// I don't know what to write here
        /// </summary>
        /// <param name="action">Object</param>
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }
        #region Private

        private void Resize()
        {
            int[] arrWithIncreasedCapacity = new int[innerArr.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                arrWithIncreasedCapacity[i] = innerArr[i];
            }

            innerArr = arrWithIncreasedCapacity;
        }
        private void CheckForEmptyStack()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }
        }
        private void CheckSizeOfArray()
        {
            if (innerArr.Length == Count)
            {
                Resize();
            }
        }
        #endregion
    }
}
