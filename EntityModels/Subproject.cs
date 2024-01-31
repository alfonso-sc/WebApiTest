using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class Subproject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ProjectId { get; set; }

    public string? Notes { get; set; }

    public int? EstimatedHours { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    public virtual ICollection<FavoritesXref> FavoritesXrefs { get; set; } = new List<FavoritesXref>();

    public virtual Project? Project { get; set; }
}
