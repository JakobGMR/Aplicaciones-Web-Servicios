using SoccerGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoccerGame.Infrastructure.Data.Configurations;

public class PartidoConfiguration : IEntityTypeConfiguration<Partido>
{
    public void Configure(EntityTypeBuilder<Partido> builder)
    {
        builder.ToTable("Partidos");

        builder.HasKey(e => e.PartidoId).HasName("PK__Partidos__DBC2E8D694FDCF5B");

            builder.Property(e => e.PartidoId)
                .ValueGeneratedNever()
                .HasColumnName("PartidoID");
            builder.Property(e => e.EquipoLocalId).HasColumnName("EquipoLocalID");
            builder.Property(e => e.EquipoVisitanteId).HasColumnName("EquipoVisitanteID");
            builder.Property(e => e.FechaJuego).HasColumnType("date");

            builder.HasOne(d => d.EquipoLocal).WithMany(p => p.PartidosEquipoLocal)
                .HasForeignKey(d => d.EquipoLocalId)
                .HasConstraintName("FK__Partidos__Equipo__403A8C7D");

            builder.HasOne(d => d.EquipoVisitante).WithMany(p => p.PartidosEquipoVisitante)
                .HasForeignKey(d => d.EquipoVisitanteId)
                .HasConstraintName("FK__Partidos__Equipo__412EB0B6");
    }
}