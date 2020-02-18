using System;

namespace SULS.BindingModels.Submissions
{
    public class DetailsSubmissionBindingModel
    {
        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
