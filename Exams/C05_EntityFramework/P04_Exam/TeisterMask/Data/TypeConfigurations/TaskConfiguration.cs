using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TeisterMask.Data.Models;

namespace TeisterMask.Data.TypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(p => p.ProjectId);
        }
    }
}
