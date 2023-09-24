namespace JaveragesLibrary.Domain.Dtos;

public class UsuarioDTO
{
    public int Id { get; set; }
    public required string Name { get; set; } = null!;
    public required string Lastname { get; set; } = null!;
    public required string Age { get; set; }
    public required string Email { get; set; } = null!;
    public required string Password { get; set; } = null!;
    public int PublicationYear { get; set; }
}