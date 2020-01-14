using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class ResourseConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                .ToTable("Resources");

            builder
                .HasKey(r => r.ResourceId);

            builder
                .Property(r => r.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(r => r.Url)
                .IsUnicode(false);

            builder.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
