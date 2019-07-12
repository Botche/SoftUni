using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    class Lake<T> : IEnumerable<T>
    {
        private List<T> lake;

        public Lake(T[] stones)
        {
            lake = stones.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < lake.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return lake[i];
                }
            }
            for (int i = lake.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
