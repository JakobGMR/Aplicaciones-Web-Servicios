using System;
using System.Collections.Generic;
using SoccerGame.Domain.Entities;

namespace SoccerGame.Domain.Dtos;

public partial class PartidoDto
{
    public int PartidoId { get; set; }

    // public int? ResultadoLocal { get; set; }

    // public int? ResultadoVisitante { get; set; }
    public int? EquipoLocalId { get; set; }

    public int? EquipoVisitanteId { get; set; }
    public DateTime? FechaJuego {get; set;}

    public virtual TeamDto? EquipoLocal { get; set; }

    public virtual TeamDto? EquipoVisitante { get; set; }
}