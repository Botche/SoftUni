using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.TypeConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Customer)
                .WithMany(p => p.Tickets)
                .HasForeignKey(k => k.CustomerId);

            builder
                .HasOne(p => p.Projection)
                .WithMany(p => p.Tickets)
                .HasForeignKey(k => k.ProjectionId);
        }
    }
}
