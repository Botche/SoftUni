using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left,T rigth)
        {
            this.left = left;
            this.right = rigth;
        }

        public bool AreEqual()
        {
            bool result = this.left.Equals(this.right);

            return result;

        }
    }
}
