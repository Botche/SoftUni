using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Writer)
                .WithMany(p => p.Songs)
                .HasForeignKey(k => k.WriterId);

            builder
                .HasOne(p => p.Album)
                .WithMany(p => p.Songs)
                .HasForeignKey(k => k.AlbumId);
        }
    }
}
