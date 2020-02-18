using System;
using System.Collections.Generic;
using System.Text;
using Andreys.App.ViewModels;
using Andreys.Models;
using Andreys.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var product = this.productsService.GetProductDetails(id);

            if (product == null)
            {
                return this.Redirect("/");
            }

            return this.View(product);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(InputAddProductModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Name.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Name.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Price == "")
            {
                return this.Redirect("/Products/Add");
            }

            var isParsedCategory = Enum.TryParse(typeof(Category), input.Category, out object categoryObject);
            if (!isParsedCategory)
            {
                return this.Redirect("/Products/Add");
            }
            var category = (Category)categoryObject;

            var isParsedGender = Enum.TryParse(typeof(Gender), input.Gender, out object genderObject);
            if (!isParsedGender)
            {
                return this.Redirect("/Products/Add");
            }
            var gender = (Gender)genderObject;

            this.productsService.AddProduct(input.Name,
                input.Description,
                input.ImageUrl,
                category,
                gender,
                decimal.Parse(input.Price));

            return this.Redirect("/Home/Home");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var product = this.productsService.GetProductDetails(id);

            if (product != null)
            {
                this.productsService.DeleteProductDetails(product);
            }

            return this.Redirect("/");
        }
    }
}
