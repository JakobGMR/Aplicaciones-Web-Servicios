using System;
using System.Collections.Generic;

namespace JaveragesLibrary.Domain.Entities;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Manga> Manga { get; set; } = new List<Manga>();
}
