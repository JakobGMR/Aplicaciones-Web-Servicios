namespace JaveragesLibrary.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public required string Age { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateTime PublicationDate { get; set; }
}