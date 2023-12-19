using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoccerGame.Domain.Dtos;

public partial class NombreEquipoDto
{
    public string NombreEquipo { get; set; } = null!;
}