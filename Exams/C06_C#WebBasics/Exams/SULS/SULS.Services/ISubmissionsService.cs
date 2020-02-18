using SULS.BindingModels.Submissions;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void CreateSubmission(string code, string problemId, string userId);
        DetailsSubmssionBindingModel GetSubmissionById(string submissionId);
        void DeleteSubmission(string id);
    }
}
