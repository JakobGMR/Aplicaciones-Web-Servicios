using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class RutaDeAprendizajeConfiguration : IEntityTypeConfiguration<RutaDeAprendizaje>
{
    public void Configure(EntityTypeBuilder<RutaDeAprendizaje> builder) {
        builder.ToTable("RutaDeAprendizaje");

        builder.HasNoKey();

        builder.Property(e => e.ClaseId).HasColumnName("ClaseID");
        
        builder.Property(e => e.MateriaId).HasColumnName("MateriaID");

        builder.HasOne(d => d.Clase).WithMany()
            .HasForeignKey(d => d.ClaseId)
            .HasConstraintName("FK__RutaDeApr__Clase__1EA48E88");

        builder.HasOne(d => d.Materia).WithMany()
            .HasForeignKey(d => d.MateriaId)
            .HasConstraintName("FK__RutaDeApr__Mater__1F98B2C1");

        builder.HasOne(d => d.Profesor).WithMany()
            .HasForeignKey(d => d.ProfesorId)
            .HasConstraintName("FK__RutaDeApr__Profe__208CD6FA");
    }
}