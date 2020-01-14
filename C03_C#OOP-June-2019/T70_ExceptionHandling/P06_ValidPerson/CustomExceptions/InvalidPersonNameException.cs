using System;
using System.Collections.Generic;
using System.Text;

namespace P06_ValidPerson.CustomExceptions
{
    [Serializable]
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {

        }

        public InvalidPersonNameException(string name)
            : base(String.Format("Invalid Person Name: {0}", name))
        {

        }
    }
}
