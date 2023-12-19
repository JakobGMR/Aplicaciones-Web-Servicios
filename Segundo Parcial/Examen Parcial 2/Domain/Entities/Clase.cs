using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatemApi.Domain.Entities;

public partial class Clase
{
    public int IdClase { get; set; }

    public int Grado { get; set; }

    public string Grupo { get; set; } = null!;

    public int Año { get; set; }
    [JsonIgnore]
    public virtual ICollection<Alumno> Alumno { get; set; } = new List<Alumno>();
}
