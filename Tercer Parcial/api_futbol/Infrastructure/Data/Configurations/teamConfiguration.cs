using SoccerGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoccerGame.Infrastructure.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Team");

        builder.HasKey(e => e.EquipoId).HasName("PK__Team__DE8A0BFF55825A58");

            builder.Property(e => e.EquipoId)
                .ValueGeneratedNever()
                .HasColumnName("EquipoID");
            builder.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.Estadio)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Logo).IsUnicode(false);
            builder.Property(e => e.NombreEquipo).HasMaxLength(50);
    }
}