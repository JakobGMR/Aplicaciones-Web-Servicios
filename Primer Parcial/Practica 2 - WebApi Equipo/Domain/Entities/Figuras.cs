namespace JaveragesLibrary.Domain.Entities;

public class Figura
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required float Price { get; set; }
    public required string Author { get; set; }
    public required string Size { get; set; }
    public DateTime PublicationDate { get; set; }
}