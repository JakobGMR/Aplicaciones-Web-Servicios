using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Data.Configurations;

namespace SoccerGame.Infrastructure.Data;

public partial class SoccerGameDbContext : DbContext
{
    public SoccerGameDbContext()
    {
    }

    public SoccerGameDbContext(DbContextOptions<SoccerGameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jugador> Jugadores { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JugadorConfiguration());
        modelBuilder.ApplyConfiguration(new PartidoConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
