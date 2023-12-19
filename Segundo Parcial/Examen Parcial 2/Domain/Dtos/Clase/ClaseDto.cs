using MatemApi.Domain.Entities;

namespace MatemApi.Domain.Dtos;

public partial class ClaseDto
{
    public int IdClase { get; set; }
    public int Grado { get; set; }
    public string Grupo { get; set; } = null!;
    public int Año { get; set; }
    public virtual ICollection<AlumnoClaseDto>? Alumnos { get; set; } = new List<AlumnoClaseDto>();
}