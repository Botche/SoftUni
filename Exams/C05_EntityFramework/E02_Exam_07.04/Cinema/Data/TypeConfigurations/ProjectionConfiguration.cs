using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.TypeConfigurations
{
    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Hall)
                .WithMany(p => p.Projections)
                .HasForeignKey(k => k.HallId);

            builder
                .HasOne(p => p.Movie)
                .WithMany(p => p.Projections)
                .HasForeignKey(k => k.MovieId);
        }
    }
}
