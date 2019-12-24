using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TeisterMask.Data.Models;

namespace TeisterMask.Data.TypeConfigurations
{
    public class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> builder)
        {
            builder
                .HasKey(k => new { k.EmployeeId, k.TaskId });

            builder
                .HasOne(p => p.Task)
                .WithMany(p => p.EmployeesTasks)
                .HasForeignKey(k => k.TaskId);

            builder
                .HasOne(p => p.Employee)
                .WithMany(p => p.EmployeesTasks)
                .HasForeignKey(k => k.EmployeeId);
        }
    }
}
