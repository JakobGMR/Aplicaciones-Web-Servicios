namespace MatemApi.Domain.Entities;

public class TutorCreateDto
{
    public string Correo { get; set; } = null!;
    public string? Nombres { get; set; } = null!;
    public string? Apellidos { get; set; } = null!;
}