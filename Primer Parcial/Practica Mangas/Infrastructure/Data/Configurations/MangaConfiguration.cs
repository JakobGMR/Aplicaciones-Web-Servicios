using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JaveragesLibrary.Infrastructure.Data.Configurations;

public class MangaConfiguration : IEntityTypeConfiguration<Manga>
{
    public void Configure(EntityTypeBuilder<Manga> builder)
    {
        builder.ToTable("Mangas");

        builder.HasKey(e => e.Id).HasName("PK__Mangas__3214EC074FB6BEF2");

        builder.Property(e => e.PublicationDate).HasColumnType("datetime");
        builder.Property(e => e.PublishingFrequency).HasMaxLength(255);
        builder.Property(e => e.Title).HasMaxLength(255);
        builder.Property(e => e.Type).HasMaxLength(255);

        builder.HasMany(d => d.Artists).WithMany(p => p.Manga)
            .UsingEntity<Dictionary<string, object>>(
                "MangaArtists",
                r => r.HasOne<Artist>().WithMany()
                    .HasForeignKey("ArtistId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MangaArti__Artis__4222D4EF"),
                l => l.HasOne<Manga>().WithMany()
                    .HasForeignKey("MangaId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MangaArti__Manga__412EB0B6"),
                j =>
                {
                    j.HasKey("MangaId", "ArtistId").HasName("PK__MangaArt__8953097BAE179845");
                });
    }
}