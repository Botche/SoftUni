using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Musaka.App.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }
    }
}
