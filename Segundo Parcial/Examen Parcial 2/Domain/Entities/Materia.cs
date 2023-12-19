using System;
using System.Collections.Generic;

namespace MatemApi.Domain.Entities;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string Categoría { get; set; } = null!;

    public int Nivel { get; set; }

    public string? Descripción { get; set; }
}
