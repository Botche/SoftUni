using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Common
{
    class Validator
    {
        public static void ThrowIfStringIsEmptyOrNull(string value,string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfObjectIsNull(object value,string message)
        {
            if (value == null)
            {
                throw new NullReferenceException(message);
            }
        }
    }
}
