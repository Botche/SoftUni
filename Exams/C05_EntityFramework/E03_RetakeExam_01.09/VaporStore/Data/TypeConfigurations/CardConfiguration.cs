using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.TypeConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Cards)
                .HasForeignKey(k => k.UserId);
        }
    }
}
