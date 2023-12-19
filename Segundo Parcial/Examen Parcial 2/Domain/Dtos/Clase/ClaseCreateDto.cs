using MatemApi.Domain.Entities;

namespace MatemApi.Domain.Dtos;

public partial class ClaseCreateDto
{
    public int Grado { get; set; }
    public string Grupo { get; set; } = null!;
    public int Año { get; set; }
}