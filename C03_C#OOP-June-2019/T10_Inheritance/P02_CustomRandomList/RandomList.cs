using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random rnd;
        public RandomList()
        {
            rnd = new Random();
        }
        public string RandomString()
        {
            string strToRemove = null;
            int index = rnd.Next(0, base.Count);

            if (base.Contains(base[index]))
            {
                strToRemove =base[index];
                base.Remove(strToRemove);
            }

            return strToRemove;
        }
    }
}
