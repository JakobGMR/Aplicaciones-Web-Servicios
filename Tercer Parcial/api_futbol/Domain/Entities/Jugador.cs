using System;
using System.Collections.Generic;

namespace SoccerGame.Domain.Entities;

public partial class Jugador
{
    public int JugadorId { get; set; }

    public string NombreJugador { get; set; } = null!;

    public int? EquipoId { get; set; }

    public string? Numero { get; set; }

    public string? Posicion { get; set; }

    public virtual Team? Equipo { get; set; }
}
