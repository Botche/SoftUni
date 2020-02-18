using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andreys.BindingModels;
using Andreys.Data;
using Andreys.Models;
using Andreys.Services.Interfaces;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContex db;

        public ProductsService(AndreysDbContex db)
        {
            this.db = db;
        }

        public void AddProduct(string name, string description, string url, Category category, Gender gender, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                ImageUrl = url,
                Category = category,
                Gender = gender,
                Price = price
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<DetailsProducts> GetAllProducts()
            => this.db.Products
            .Select(product => new DetailsProducts
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price
            })
            .ToArray();

        public Product GetProductDetails( string productId)
            => this.db.Products
            .Where(product => product.Id == productId)
            .Select(product => new Product
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Gender = product.Gender,
                Price = product.Price
            })
            .FirstOrDefault();

        public void DeleteProductDetails(Product product)
        {
            this.db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
