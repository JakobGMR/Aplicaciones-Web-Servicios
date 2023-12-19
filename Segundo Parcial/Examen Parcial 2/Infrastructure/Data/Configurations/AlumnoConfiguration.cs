using MatemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatemApi.Infrastructure.Data.Configurations;

public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable("Alumno");

        builder.HasKey(e => e.Id).HasName("PK__Alumno__3214EC07BA83CB88");

        builder.HasIndex(e => e.CorreoElectronico, "UQ__Alumno__E0991C1BD8652A49").IsUnique();

        builder.Property(e => e.Apellidos)
            .HasMaxLength(50)
            .IsUnicode(false);
            
        builder.Property(e => e.CorreoElectronico)
            .HasMaxLength(70)
            .IsUnicode(false)
            .HasColumnName("Correo_electronico");
        builder.Property(e => e.IdClase).HasColumnName("Id_Clase");
        
        builder.Property(e => e.IdTutor).HasColumnName("Id_Tutor");
        
        builder.Property(e => e.Nombres)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Alumno)
            .HasForeignKey(d => d.IdClase)
            .HasConstraintName("FK__Alumno__Id_Clase__25518C17");

        builder.HasOne(d => d.IdTutorNavigation).WithMany(p => p.Alumnos)
            .HasForeignKey(d => d.IdTutor)
            .HasConstraintName("FK__Alumno__Id_Tutor__245D67DE");
    }
}