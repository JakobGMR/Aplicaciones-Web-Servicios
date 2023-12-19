using System;
using System.Collections.Generic;

namespace MatemApi.Domain.Entities;

public partial class Profesor
{
    public int Id { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaDeRegistro { get; set; }
}
