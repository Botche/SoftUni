using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Model
{
    class AddRemoveCollection : IAddable, IRemovable
    {
        private List<string> list;
        public AddRemoveCollection()
        {
            list = new List<string>();
        }
        public int Add(string element)
        {
            int indexToInsert = 0;

            list.Insert(indexToInsert, element);

            return indexToInsert;
        }

        public string Remove()
        {
            var elementToRemove = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return elementToRemove;
        }
    }
}
