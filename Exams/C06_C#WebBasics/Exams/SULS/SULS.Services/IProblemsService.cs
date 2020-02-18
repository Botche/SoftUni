using System.Collections.Generic;

using SULS.BindingModels.Problems;
using SULS.BindingModels.Submissions;

namespace SULS.Services
{
    public interface IProblemsService
    { 
        void CreateProblem(string name, int points);

        IEnumerable<ProblemsBindingModel> GetAllProblems();

        DetailsProblemBindingModel GetProblemWithAllSubmissions(string id, string userId);

        SubmissonCreateBindingModel GetProblemIdAndName(string id);

        ProblemCreateSubmissionBindingModel GetProblemIdAndPoints(string id);
    }
}
