using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericSwapMethodString
{
    class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {this.value}";
        }
    }
}
