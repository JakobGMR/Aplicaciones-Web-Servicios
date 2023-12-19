using System;
using System.Collections.Generic;

namespace MatemApi.Domain.Entities;

public partial class RutaDeAprendizaje
{
    public int? ClaseId { get; set; }

    public int? MateriaId { get; set; }

    public int? ProfesorId { get; set; }

    public virtual Clase? Clase { get; set; }

    public virtual Materia? Materia { get; set; }

    public virtual Profesor? Profesor { get; set; }
}
