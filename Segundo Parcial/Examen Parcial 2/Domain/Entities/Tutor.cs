using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatemApi.Domain.Entities;

public partial class Tutor
{
    public int Id { get; set; }

    public string Correo { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
