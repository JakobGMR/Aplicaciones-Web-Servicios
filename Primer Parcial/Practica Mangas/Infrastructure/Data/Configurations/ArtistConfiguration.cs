using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JaveragesLibrary.Infrastructure.Data.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists");

        builder.HasKey(e => e.Id).HasName("PK__Artists__3214EC0797C66C30");

        builder.Property(e => e.Name).HasMaxLength(255);
    }
}