using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;

public partial class TeamDto
{
    public int EquipoId { get; set; }

    public string NombreEquipo { get; set; } = null!;
    public string? Logo { get; set; }

    public string? Estadio { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<JugadoresDto> Jugadores { get; set; } = new List<JugadoresDto>();
}