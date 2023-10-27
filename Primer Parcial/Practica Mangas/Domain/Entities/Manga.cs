using System;
using System.Collections.Generic;

namespace JaveragesLibrary.Domain.Entities;

public partial class Manga 
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public string? Description { get; set; }

    public bool IsColorEdition { get; set; }

    public string? PublishingFrequency { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<License> License { get; set; } = new List<License>();

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
}
