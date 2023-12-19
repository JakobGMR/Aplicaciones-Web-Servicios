using System.Security.Principal;
using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
{
    public void Configure(EntityTypeBuilder<Materia> builder) {
        builder.ToTable("Materia");

        builder.HasKey(e => e.IdMateria).HasName("PK__Materia__D3FE91FA5C731219");

            builder.Property(e => e.IdMateria).HasColumnName("Id_Materia");
            builder.Property(e => e.Categoría)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Descripción).IsUnicode(false);
    }
}