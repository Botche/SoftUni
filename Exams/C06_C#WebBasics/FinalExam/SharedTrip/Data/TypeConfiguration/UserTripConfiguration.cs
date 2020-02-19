using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedTrip.Models;

namespace SharedTrip.Data.TypeConfiguration
{
    public class UserTripConfiguration : IEntityTypeConfiguration<UserTrip>
    {
        public void Configure(EntityTypeBuilder<UserTrip> builder)
        {
            builder
                .HasKey(k => new { k.TripId, k.UserId });

            builder
                .HasOne(u => u.User)
                .WithMany(ut => ut.UserTrips)
                .HasForeignKey(u => u.UserId);

            builder
                .HasOne(t => t.Trip)
                .WithMany(ut => ut.UserTrips)
                .HasForeignKey(t => t.TripId);
        }
    }
}
