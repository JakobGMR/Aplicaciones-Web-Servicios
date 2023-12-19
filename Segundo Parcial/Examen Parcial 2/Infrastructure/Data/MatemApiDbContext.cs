using System;
using System.Collections.Generic;
using MatemApi.Domain.Entities;
using MatemApi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MatemApi.Infrastructure.Data;

public partial class MatemApiDbContext : DbContext
{
    public MatemApiDbContext()
    {
    }

    public MatemApiDbContext(DbContextOptions<MatemApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Profesor> Profesores { get; set; }

    public virtual DbSet<RutaDeAprendizaje> RutaDeAprendizajes { get; set; }

    public virtual DbSet<Tutor> Tutores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlumnoConfiguration());
        modelBuilder.ApplyConfiguration(new ClaseConfiguration());
        modelBuilder.ApplyConfiguration(new MateriaConfiguration());
        modelBuilder.ApplyConfiguration(new ProfesorConfiguration());
        modelBuilder.ApplyConfiguration(new RutaDeAprendizajeConfiguration());
        modelBuilder.ApplyConfiguration(new TutorConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
