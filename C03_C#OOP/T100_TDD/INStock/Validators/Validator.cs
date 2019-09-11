using System;

namespace INStock.Validators
{
    public static class Validator
    {
        public static void ValidateStringIsNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateDecimalIsZeroOrBelow(decimal value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateQuantityIsBelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
