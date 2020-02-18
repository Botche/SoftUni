using System;
using System.Linq;

using SULS.BindingModels.Submissions;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;
        private readonly IUsersService usersService;
        private readonly IProblemsService problemsService;

        public SubmissionsService(SULSContext db, IUsersService usersService, IProblemsService problemsService)
        {
            this.db = db;
            this.usersService = usersService;
            this.problemsService = problemsService;
        }

        public void CreateSubmission(string code, string problemId, string userId)
        {
            var rnd = new Random();
            var problem = this.problemsService.GetProblemIdAndPoints(problemId);

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problem.Id,
                CreatedOn = DateTime.Now,
                AchievedResult = rnd.Next(0, problem.MaxPoints + 1),
                UserId = userId
            };

            this.db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public void DeleteSubmission(string id)
        {
            var submission = this.db.Submissions.FirstOrDefault(submission => submission.Id == id);

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }

        public DetailsSubmssionBindingModel GetSubmissionById(string submissionId)
            => this.db.Submissions
            .Where(submission => submission.Id == submissionId)
            .Select(submission => new DetailsSubmssionBindingModel
            {
                Id = submission.Id,
                ProblemId = submission.ProblemId
            })
            .FirstOrDefault();
    }
}
