using System.Collections.Generic;
using System.Linq;

using SULS.BindingModels.Problems;
using SULS.BindingModels.Submissions;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;
        private readonly IUsersService usersService;

        public ProblemsService(SULSContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points
            };

            db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IEnumerable<ProblemsBindingModel> GetAllProblems()
            => this.db.Problems
            .Select(problem => new ProblemsBindingModel
            {
                Id = problem.Id,
                Name = problem.Name,
                Count = problem.Submissions.Count
            })
            .ToArray();

        public DetailsProblemBindingModel GetProblemWithAllSubmissions(string id, string userId)
            => this.db.Problems
            .Where(problem => problem.Id == id)
            .Select(problem => new DetailsProblemBindingModel
            {
                Name = problem.Name,
                Username = this.usersService.GetUsernameById(userId),
                Submissions = problem.Submissions.Select(submission => new DetailsSubmissionBindingModel
                {
                    SubmissionId = submission.Id,
                    Username = submission.User.Username,
                    AchievedResult = submission.AchievedResult,
                    MaxPoints = submission.Problem.Points,
                    CreatedOn = submission.CreatedOn
                })
            })
            .FirstOrDefault();

        public SubmissonCreateBindingModel GetProblemIdAndName(string id)
             => this.db.Problems
            .Where(problem => problem.Id == id)
            .Select(problem => new SubmissonCreateBindingModel
            {
                ProblemId = problem.Id,
                Name = problem.Name
            })
            .FirstOrDefault();

        public ProblemCreateSubmissionBindingModel GetProblemIdAndPoints(string id)
             => this.db.Problems
            .Where(problem => problem.Id == id)
            .Select(problem => new ProblemCreateSubmissionBindingModel
            {
                Id = problem.Id,
                MaxPoints = problem.Points
            })
            .FirstOrDefault();
    }
}
