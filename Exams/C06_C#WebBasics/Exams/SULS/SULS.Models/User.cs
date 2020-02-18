using System;
using System.Collections.Generic;

using SIS.MvcFramework;

namespace SULS.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new List<Submission>();
            this.Role = IdentityRole.User;
        }

        public ICollection<Submission> Submissions { get; set; }
    }
}