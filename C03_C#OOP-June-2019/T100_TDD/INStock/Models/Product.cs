using INStock.Contracts;
using INStock.Messages;
using INStock.Validators;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string labelName, decimal price, int quantity)
        {
            Label = labelName;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => label;
            private set
            {
                Validator.ValidateStringIsNullOrWhiteSpace(value, ExceptionMessages.LabelIsNullOrWhiteSpace);

                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                Validator.ValidateDecimalIsZeroOrBelow(value, ExceptionMessages.PriceIsZeroOrBelow);
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            private set
            {
                Validator.ValidateQuantityIsBelowZero(value, ExceptionMessages.QuantityIsBelowZero);
                quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
