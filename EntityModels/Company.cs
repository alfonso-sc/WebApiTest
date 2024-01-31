using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
