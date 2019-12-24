using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.TypeConfigurations
{
    public class GameTagConfiguration : IEntityTypeConfiguration<GameTag>
    {
        public void Configure(EntityTypeBuilder<GameTag> builder)
        {
            builder
                .HasKey(k => new { k.GameId, k.TagId });

            builder
                .HasOne(p => p.Game)
                .WithMany(p => p.GameTags)
                .HasForeignKey(k => k.GameId);

            builder
                .HasOne(p => p.Tag)
                .WithMany(p => p.GameTags)
                .HasForeignKey(k => k.TagId);
        }
    }
}
