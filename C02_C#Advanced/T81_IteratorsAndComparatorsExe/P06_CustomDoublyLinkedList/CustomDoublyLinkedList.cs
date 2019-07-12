using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>:IEnumerable<T>
    {
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode(T value)
            {
                Value = value;
            }

        }
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; } = 0;

        // void AddFirst(int element) – adds an element at the beginning of the collection
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }
        // void AddLast(int element) – adds an element at the end of the collection
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }
        // int RemoveFirst() – removes the element at the beginning of the 
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;
            head = head.NextNode;
            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return firstElement;
        }
        // int RemoveLast() – removes the element at the end of the collection
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;
            tail = tail.PreviousNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;
            return lastElement;
        }
        // void ForEach() – goes through the collection and executes a given action
        public void ForEach(Action<T> action)
        {
            var currentNode = head;
            while (currentNode!=null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }
        // int[] ToArray() – returns the collection as an array
        public T[] ToArray()
        {
            T[] arr = new T[Count];
            int counter = 0;
            var currentNode = head;

            while(currentNode!=null)
            {
                arr[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
