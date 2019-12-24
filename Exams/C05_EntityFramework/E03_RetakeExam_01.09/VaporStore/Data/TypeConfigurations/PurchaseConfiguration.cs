using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.TypeConfigurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Game)
                .WithMany(p => p.Purchases)
                .HasForeignKey(k => k.GameId);

            builder
                .HasOne(p => p.Card)
                .WithMany(p => p.Purchases)
                .HasForeignKey(k => k.CardId);
        }
    }
}
