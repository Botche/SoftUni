using System.Collections.Generic;

using SULS.BindingModels.Submissions;

namespace SULS.BindingModels.Problems
{
    public class DetailsProblemBindingModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public IEnumerable<DetailsSubmissionBindingModel> Submissions { get; set; }
    }
}
