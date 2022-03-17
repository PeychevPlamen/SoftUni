﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data.Models;

namespace MusicSpot.Data
{
    public class MusicSpotDbContext : IdentityDbContext
    {
        public MusicSpotDbContext(DbContextOptions<MusicSpotDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; init; }

        public DbSet<Artist> Artists { get; init; }

        public DbSet<Track> Tracks { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Track>()
                .HasOne(a => a.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(a => a.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Artist>()
            //    .HasMany(a => a.Albums)
            //    .WithOne(a => a.Artist)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}