using System;
using System.Collections.Generic;
using SoccerGame.Domain.Entities;

namespace SoccerGame.Domain.Dtos;

public partial class JugadorCreateDto
{
    public int JugadorId { get; set; }
    public string NombreJugador { get; set; } = null!;
    public string? Numero { get; set; }
    public string? Posicion { get; set; }
    public int? EquipoId { get; set; }
}
