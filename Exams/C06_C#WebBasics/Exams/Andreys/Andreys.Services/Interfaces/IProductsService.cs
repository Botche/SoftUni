using System;
using System.Collections.Generic;
using System.Text;
using Andreys.BindingModels;
using Andreys.Models;

namespace Andreys.Services.Interfaces
{
    public interface IProductsService
    {
        void AddProduct(string name, string description, string url, Category category, Gender gender, decimal price);

        IEnumerable<DetailsProducts> GetAllProducts();

        void DeleteProductDetails(Product product);

        Product GetProductDetails(string productId);
    }
}
