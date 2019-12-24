using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configurations
{
    public class SongPerformerConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> builder)
        {
            builder
                .HasKey(k => new { k.PerformerId, k.SongId });

            builder
                .HasOne(p => p.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(k => k.PerformerId);

            builder
                .HasOne(p => p.Song)
                .WithMany(p => p.SongPerformers)
                .HasForeignKey(k => k.SongId);
        }
    }
}
