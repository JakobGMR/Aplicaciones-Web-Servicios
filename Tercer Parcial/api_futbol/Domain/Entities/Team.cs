using System;
using System.Collections.Generic;

namespace SoccerGame.Domain.Entities;

public partial class Team
{
    public int EquipoId { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public string? Logo { get; set; }

    public string? Estadio { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();

    public virtual ICollection<Partido> PartidosEquipoLocal { get; set; } = new List<Partido>();

    public virtual ICollection<Partido> PartidosEquipoVisitante { get; set; } = new List<Partido>();
}
