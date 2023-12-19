using MatemApi.Domain.Entities;

namespace MatemApi.Domain.Dtos;

public partial class ClaseDtoAll
{
    public int IdClase { get; set; }
    public int Grado { get; set; }
    public string Grupo { get; set; } = null!;
    public int Año { get; set; }
    // public virtual ICollection<Alumno>? Alumnos { get; set; } = new List<Alumno>();
}