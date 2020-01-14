using INStock.Contracts;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private IList<IProduct> productStock;

        public ProductStock()
        {
            productStock = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get => productStock[index];
            set => productStock[index] = value;
        }

        public int Count => productStock.Count;

        public void Add(IProduct product)
        {
            productStock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (Product item in productStock)
            {
                if (product.CompareTo(item) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IProduct Find(int index)
        {
            try
            {
                return productStock.ElementAt(index - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        public IProduct FindByLabel(string label)
        {
            var product = productStock.FirstOrDefault(p => p.Label == label);

            if (product != null)
            {
                return product;
            }

            throw new ArgumentException("No such a product is in stock");
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            var products = new List<IProduct>();

            foreach (Product product in productStock)
            {
                if (product.Price >= lo && product.Price <= hi)
                {
                    products.Add(product);
                }
            }

            return products.OrderByDescending(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            var products = new List<IProduct>();

            foreach (Product product in productStock)
            {
                if (product.Price == price)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        public IProduct FindMostExpensiveProduct()
        {
            var price = productStock.Max(p => p.Price);

            return productStock.FirstOrDefault(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var products = new List<IProduct>();

            foreach (Product product in productStock)
            {
                if (product.Quantity == quantity)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        public bool Remove(IProduct product)
        {
            return productStock.Remove(product);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
