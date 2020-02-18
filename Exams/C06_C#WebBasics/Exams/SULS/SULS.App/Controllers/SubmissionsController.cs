using SIS.HTTP;
using SIS.MvcFramework;

using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.GetProblemIdAndName(id);

            if (problem == null)
            {
                return this.Error("Such a problem does not exists.");
            }

            return this.View(problem);
        }

        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            if (code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code must be between 30 and 800 symbols");
            }

            var problem = this.problemsService.GetProblemIdAndName(problemId);

            if (problem == null)
            {
                return this.Error("Such a problem does not exists.");
            }

            var userId = this.User;
            this.submissionsService.CreateSubmission(code, problem.ProblemId, userId);

            return this.Redirect($"/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var submission = this.submissionsService.GetSubmissionById(id);

            if (submission == null)
            {
                return this.Error("Such a submission does not exists.");
            }

            this.submissionsService.DeleteSubmission(submission.Id);

            return this.Redirect("/");
        }
    }
}
