using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Model
{
    public class MyList : IAddable, IRemovable
    {
        private List<string> list;
        public MyList()
        {
            list = new List<string>();
        }

        public int Used => list.Count;
        public int Add(string element)
        {
            int indexToInsert = 0;

            list.Insert(indexToInsert, element);

            return indexToInsert;
        }

        public string Remove()
        {
            var stringToRemove = list[0];

            list.RemoveAt(0);

            return stringToRemove;
        }
    }
}
