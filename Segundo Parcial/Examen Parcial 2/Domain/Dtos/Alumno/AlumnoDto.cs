using MatemApi.Domain.Entities;

namespace MatemApi.Domain.Dtos;

public partial class AlumnoDto
{
    public string? CorreoElectronico { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public virtual Tutor? Tutor { get; set; }
    public virtual Clase? Clase { get; set; }
    public virtual ICollection<MateriaDto> Materias { get; set; } = new List<MateriaDto>();
}