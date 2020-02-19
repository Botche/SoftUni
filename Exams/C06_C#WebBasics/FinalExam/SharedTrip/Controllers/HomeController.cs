namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    { 
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.IndexLoggedIn();
            }

            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Index();
            }

            return this.Redirect("/Trips/All");
        }
    }
}