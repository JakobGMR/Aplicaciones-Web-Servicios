namespace SoccerGame.Domain.Dtos;
public partial class TeamCreateDto
{
    public int EquipoId { get; set; }
    public string NombreEquipo { get; set; } = null!;
    public string? Logo { get; set; }

    public string? Estadio { get; set; }

    public string? Ciudad { get; set; }
}