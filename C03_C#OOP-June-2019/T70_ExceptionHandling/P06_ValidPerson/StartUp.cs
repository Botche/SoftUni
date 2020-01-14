using P06_ValidPerson.CustomExceptions;
using System;
using System.Text.RegularExpressions;

namespace P06_ValidPerson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person = null;

            try
            {
                person = new Person("James007","Bond",20);

                ValidateStudent(person);
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ValidateStudent(Person prsn)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(prsn.FirstName))
            {
                throw new InvalidPersonNameException(prsn.FirstName);
            }
            if (!regex.IsMatch(prsn.LastName))
            {
                throw new InvalidPersonNameException(prsn.LastName);
            }

        }
    }
}
