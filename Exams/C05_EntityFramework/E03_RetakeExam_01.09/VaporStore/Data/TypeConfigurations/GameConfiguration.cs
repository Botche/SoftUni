using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.TypeConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Genre)
                .WithMany(p => p.Games)
                .HasForeignKey(k => k.GenreId);

            builder
                .HasOne(p => p.Developer)
                .WithMany(p => p.Games)
                .HasForeignKey(k => k.DeveloperId);
        }
    }
}
