using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Musaka.App.Controllers
{
    public class HomeController:Controller
    {
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View("");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse Home()
        {
            return this.Index();
        }
    }
}
