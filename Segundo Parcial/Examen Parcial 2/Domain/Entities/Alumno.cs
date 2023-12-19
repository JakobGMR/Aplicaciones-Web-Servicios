namespace MatemApi.Domain.Entities;

public partial class Alumno
{
    public int Id { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int? IdTutor { get; set; }

    public int? IdClase { get; set; }
    public virtual Clase? IdClaseNavigation { get; set; }

    public virtual Tutor? IdTutorNavigation { get; set; }
}