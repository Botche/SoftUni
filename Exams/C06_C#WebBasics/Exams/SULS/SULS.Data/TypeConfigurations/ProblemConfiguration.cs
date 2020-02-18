using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SULS.Models;

namespace SULS.Data.TypeConfigurations
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> model)
        {
            model
               .HasMany(s => s.Submissions)
               .WithOne(p => p.Problem)
               .HasForeignKey(p => p.ProblemId);
        }
    }
}
