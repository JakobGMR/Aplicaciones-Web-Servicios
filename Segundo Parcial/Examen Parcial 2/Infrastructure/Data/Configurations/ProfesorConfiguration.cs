using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder) {
        builder.ToTable("Profesor");

        builder.HasKey(e => e.Id).HasName("PK__Profesor__3214EC077F2383A4");

            builder.HasIndex(e => e.CorreoElectronico, "UQ__Profesor__85947816A03EA71F").IsUnique();

            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("Correo_Electronico");
            builder.Property(e => e.FechaDeRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_registro");
            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
    }
}