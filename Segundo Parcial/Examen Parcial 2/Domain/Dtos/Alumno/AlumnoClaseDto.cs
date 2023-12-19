using MatemApi.Domain.Entities;

namespace MatemApi.Domain.Dtos;

public partial class AlumnoClaseDto
{
    public string? CorreoElectronico { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public int? IdTutor { get; set; }
}