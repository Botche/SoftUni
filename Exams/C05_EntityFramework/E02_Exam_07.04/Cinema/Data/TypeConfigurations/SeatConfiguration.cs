using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.TypeConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Hall)
                .WithMany(p => p.Seats)
                .HasForeignKey(k => k.HallId);
        }
    }
}
