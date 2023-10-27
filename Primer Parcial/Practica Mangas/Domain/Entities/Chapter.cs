using System;
using System.Collections.Generic;

namespace JaveragesLibrary.Domain.Entities;

public partial class Chapter
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int PageCount { get; set; }

    public int? MangaId { get; set; }

    public virtual Manga? Manga { get; set; }
}
