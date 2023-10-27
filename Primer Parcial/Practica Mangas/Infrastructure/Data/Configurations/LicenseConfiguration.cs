using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JaveragesLibrary.Infrastructure.Data.Configurations;

public class LicenseConfiguration : IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.ToTable("Licenses");

        builder.HasKey(e => e.Id).HasName("PK__Licenses__3214EC07F735911C");

        builder.Property(e => e.ExpiryDate).HasColumnType("datetime");
        builder.Property(e => e.LicenseNumber).HasMaxLength(255);

        builder.HasOne(d => d.Manga).WithMany(p => p.License)
            .HasForeignKey(d => d.MangaId)
            .HasConstraintName("FK__Licenses__MangaI__398D8EEE");
    }
}