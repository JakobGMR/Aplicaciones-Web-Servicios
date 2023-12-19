using System;
using System.Collections.Generic;

namespace SoccerGame.Domain.Entities;

public partial class Partido
{
    public int PartidoId { get; set; }

    public int? EquipoLocalId { get; set; }

    public int? EquipoVisitanteId { get; set; }

    public int? ResultadoLocal { get; set; }

    public int? ResultadoVisitante { get; set; }

    public DateTime? FechaJuego { get; set; }

    public virtual Team? EquipoLocal { get; set; }

    public virtual Team? EquipoVisitante { get; set; }
}
