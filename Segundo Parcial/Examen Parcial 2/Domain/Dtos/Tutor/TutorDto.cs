namespace MatemApi.Domain.Entities;

public class TutorDto
{
    public int Id { get; set; }
    public string? Correo { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? CorreoAlumno { get; set; }
}