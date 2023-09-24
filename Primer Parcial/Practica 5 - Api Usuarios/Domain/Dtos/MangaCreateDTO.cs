namespace JaveragesLibrary.Domain.Dtos;

public class UsuarioCreateDTO
{
    public required string Name { get; set; } = null!;
    public required string Lastname { get; set; } = null!;
    public required string Age { get; set; }
    public required string Email { get; set; } = null!;
}