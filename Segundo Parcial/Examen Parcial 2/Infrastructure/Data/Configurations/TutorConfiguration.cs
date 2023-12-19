using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
{
    public void Configure(EntityTypeBuilder<Tutor> builder) {
        builder.ToTable("Tutor");

        builder.HasKey(e => e.Id).HasName("PK__Tutor__3214EC0720AF713D");

            builder.HasIndex(e => e.Correo, "UQ__Tutor__60695A1992A23942").IsUnique();

            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Correo)
                .HasMaxLength(70)
                .IsUnicode(false);
            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
    }
}