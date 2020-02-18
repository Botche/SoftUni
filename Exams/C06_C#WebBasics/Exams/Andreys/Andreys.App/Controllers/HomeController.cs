using Andreys.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class HomeController:Controller
    {
        private IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Home/Home");
            }

            return this.View();
        }

        public HttpResponse Home()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            var allProducts = this.productsService.GetAllProducts();

            return this.View(allProducts);
        }
    }
}
