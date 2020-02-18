using SIS.HTTP;
using SIS.MvcFramework;

using SULS.App.ViewModels.Problems;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(InputProblemViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Error("Problem name must be between 5 and 20 symbols.");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Error("Problem points must be between 50 and 300.");
            }

            this.problemsService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.GetProblemWithAllSubmissions(id, this.User);

            if (problem == null)
            {
                return this.Error("Such a problem does not exists.");
            }

            return this.View(problem);
        }
    }
}
