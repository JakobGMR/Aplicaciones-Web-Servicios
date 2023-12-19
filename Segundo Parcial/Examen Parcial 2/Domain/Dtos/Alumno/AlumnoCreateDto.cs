namespace MatemApi.Domain.Dtos;

public partial class AlumnoCreateDto
{
    public string CorreoElectronico { get; set; } = null!;
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public int? IdTutor{get; set;}
    public int? IdClase { get; set; }
}