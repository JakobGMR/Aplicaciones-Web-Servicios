using System;
using System.Collections.Generic;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Infrastructure.Data;

public partial class JaveragesLibraryDbContext : DbContext
{
    public JaveragesLibraryDbContext()
    {
    }

    public JaveragesLibraryDbContext(DbContextOptions<JaveragesLibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<Manga> Mangas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new ChapterConfiguration());
        modelBuilder.ApplyConfiguration(new LicenseConfiguration());
        modelBuilder.ApplyConfiguration(new MangaConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
