using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            return true;
        }
    }
}
