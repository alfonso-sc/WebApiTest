using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int ManagerId { get; set; }

    public short ExpectedHours { get; set; }

    public bool Active { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    public virtual ICollection<FavoritesXref> FavoritesXrefs { get; set; } = new List<FavoritesXref>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
