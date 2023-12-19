using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SoccerGame.Domain.Entities;

namespace SoccerGame.Domain.Dtos;

public partial class JugadorDto
{
    public int JugadorId { get; set; }

    public string NombreJugador { get; set; } = null!;
    public string? Numero { get; set; }

    public string? Posicion { get; set; }
    // public virtual Team? Equipo { get; set; }
}
