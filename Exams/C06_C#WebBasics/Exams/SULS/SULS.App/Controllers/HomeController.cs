using SIS.HTTP;
using SIS.MvcFramework;

using SULS.Services;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProblems = this.problemsService.GetAllProblems();

                return this.View(allProblems, "IndexLoggedIn");
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