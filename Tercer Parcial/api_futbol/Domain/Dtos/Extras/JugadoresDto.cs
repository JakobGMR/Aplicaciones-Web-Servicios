using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoccerGame.Domain.Dtos;

public partial class JugadoresDto
{
    public int JugadorId { get; set; }

    public string NombreJugador { get; set; } = null!;
    public string? Numero { get; set; }

    public string? Posicion { get; set; }
}