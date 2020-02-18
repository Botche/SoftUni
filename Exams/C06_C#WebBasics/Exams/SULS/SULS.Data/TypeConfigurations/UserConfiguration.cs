using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SULS.Models;

namespace SULS.Data.TypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> model)
        {
            model
                .Property(user => user.Username)
                .HasAnnotation("MinLength", 5)
                .HasMaxLength(20)
                .IsRequired(true);

            model
                .Property(user => user.Email)
                .IsRequired(true);
            model

                .Property(user => user.Password)
                .IsRequired(true);

            model
                .HasMany(s => s.Submissions)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
        }
    }
}
