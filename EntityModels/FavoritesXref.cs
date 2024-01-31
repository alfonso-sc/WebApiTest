using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class FavoritesXref
{
    public int ProjectId { get; set; }

    public int SubProjectId { get; set; }

    public int UserId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Subproject SubProject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
