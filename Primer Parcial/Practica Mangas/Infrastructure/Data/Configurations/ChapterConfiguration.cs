using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JaveragesLibrary.Infrastructure.Data.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.ToTable("Chapters");

        builder.HasKey(e => e.Id).HasName("PK__Chapters__3214EC07421FD6F4");

        builder.Property(e => e.Title).HasMaxLength(255);

        builder.HasOne(d => d.Manga).WithMany(p => p.Chapters)
            .HasForeignKey(d => d.MangaId)
            .HasConstraintName("FK__Chapters__MangaI__3C69FB99");
    }
}