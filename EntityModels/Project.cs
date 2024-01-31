using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal ChargingRate { get; set; }

    public bool Active { get; set; }

    public int CompanyId { get; set; }

    public int? ManagerId { get; set; }

    public bool FixedBid { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    public virtual ICollection<FavoritesXref> FavoritesXrefs { get; set; } = new List<FavoritesXref>();

    public virtual User? Manager { get; set; }

    public virtual ICollection<Subproject> Subprojects { get; set; } = new List<Subproject>();
}
