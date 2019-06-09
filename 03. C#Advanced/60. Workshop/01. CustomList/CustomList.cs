using System;
using System.Collections.Generic;
using System.Text;

namespace _01._CustomList
{
    class CustomList
    {
        private const int initialCapacity = 2;
        private int[] innerArr;

        /// <summary>
        /// Return count of elements 
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates new CustomList 
        /// </summary>
        public CustomList()
        {
            innerArr = new int[initialCapacity];
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">Index of value in CustomList</param>
        /// <returns>Value in given index</returns>
        public int this[int index]
        {
            get
            {
                CheckOutOfRangeException(index);

                return innerArr[index];
            }
            set
            {
                CheckOutOfRangeException(index);

                innerArr[index] = value;
            }
        }

        /// <summary>
        /// Adds element at CustomList
        /// </summary>
        /// <param name="element">Must be integer</param>
        public void Add(int element)
        {
            CheckSizeOfArray();

            innerArr[Count] = element;
            Count++;
        }

        /// <summary>
        /// Removes item at given index
        /// </summary>
        /// <param name="index">Position to remove item</param>
        /// <returns></returns>
        public int RemoveAt(int index)
        {
            CheckOutOfRangeException(index);

            int removedItem = innerArr[index];

            innerArr[index] = default;
            ShiftLeft(index);

            return removedItem;
        }

        /// <summary>
        /// Insert at given index element
        /// </summary>
        /// <param name="index">Position to place new item</param>
        /// <param name="item">Must be integer</param>
        public void InsertAt(int index, int item)
        {
            CheckOutOfRangeException(index);
            CheckSizeOfArray();

            ShiftRight(index);
            innerArr[index] = item;
        }
        // bool Contains(int element)
        /// <summary>
        /// Returns boolean
        /// </summary>
        /// <param name="element">Must be integer</param>
        /// <returns></returns>
        public bool Contains(int element)
        {
            bool isElementInArray = false;

            for (int i = 0; i < Count; i++)
            {
                if (innerArr[i] == element)
                {
                    isElementInArray = true;
                    break;
                }
            }

            return isElementInArray;
        }
        // void Swap (int firstIndex, secondIndex)
        /// <summary>
        /// Swaps two elements in CustomList
        /// </summary>
        /// <param name="firstIndex">Index of first element</param>
        /// <param name="secondIndex">Index of second element</param>
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckOutOfRangeException(firstIndex);
            CheckOutOfRangeException(secondIndex);

            var variable = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = variable;
        }

        #region Private

        private void ShiftRight(int index)
        {
            CheckSizeOfArray();

            Count++;

            for (int i = Count - 1; i > index; i--)
            {
                var variable = innerArr[i];
                innerArr[i] = innerArr[i - 1];
                innerArr[i - 1] = variable;
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                var variable = innerArr[i];
                innerArr[i] = innerArr[i + 1];
                innerArr[i + 1] = variable;
            }

            Count--;

            if (innerArr.Length/Count>=4)
            {
                Shrink();
            }
        }

        private void Shrink()
        {
            int[] arrWithDecreasedCapacity = new int[innerArr.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                arrWithDecreasedCapacity[i] = innerArr[i];
            }

            innerArr = arrWithDecreasedCapacity;

        }

        private void Resize()
        {
            int[] arrWithIncreasedCapacity = new int[innerArr.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                arrWithIncreasedCapacity[i] = innerArr[i];
            }

            innerArr = arrWithIncreasedCapacity;
        }


        private void CheckSizeOfArray()
        {
            if (innerArr.Length == Count)
            {
                Resize();
            }
        }

        private void CheckOutOfRangeException(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
    }
}
