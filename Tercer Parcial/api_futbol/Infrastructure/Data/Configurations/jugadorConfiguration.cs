using SoccerGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoccerGame.Infrastructure.Data.Configurations;

public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
{
    public void Configure(EntityTypeBuilder<Jugador> builder)
    {
        builder.ToTable("Jugadores");

        builder.HasKey(e => e.JugadorId).HasName("PK__Jugadore__4B575242E70C7269");

            builder.Property(e => e.JugadorId)
                .ValueGeneratedNever()
                .HasColumnName("JugadorID");
            builder.Property(e => e.EquipoId).HasColumnName("EquipoID");
            builder.Property(e => e.NombreJugador).HasMaxLength(50);
            builder.Property(e => e.Numero)
                .HasMaxLength(5)
                .IsUnicode(false);
            builder.Property(e => e.Posicion)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.Equipo).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.EquipoId)
                .HasConstraintName("FK__Jugadores__Equip__3D5E1FD2");
    }
}