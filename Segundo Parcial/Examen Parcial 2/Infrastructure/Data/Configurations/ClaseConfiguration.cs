using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class ClaseConfiguration : IEntityTypeConfiguration<Clase>
{
    public void Configure(EntityTypeBuilder<Clase> builder) {
        builder.ToTable("Clase");

        builder.HasKey(e => e.IdClase).HasName("PK__Clase__E30692F09348AAD6");

        builder.Property(e => e.IdClase).HasColumnName("Id_Clase");
        
        builder.Property(e => e.Grupo)
            .HasMaxLength(10)
            .IsUnicode(false);
    }
}