using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Model
{
    public class AddCollection : IAddable
    {
        private Stack<string> stack;
        public AddCollection()
        {
            stack = new Stack<string>();
        }

        public int Add(string element)
        {
            stack.Push(element);

            return stack.Count - 1;
        }
    }
}
