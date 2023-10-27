using System;
using System.Collections.Generic;

namespace JaveragesLibrary.Domain.Entities;

public partial class License
{
    public int Id { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public int? MangaId { get; set; }

    public virtual Manga? Manga { get; set; }
}
