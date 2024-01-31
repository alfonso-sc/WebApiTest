using System;
using System.Collections.Generic;

namespace WebApiTest.EntityModels;

public partial class Entry
{
    public int Id { get; set; }

    public decimal Hours { get; set; }

    public int ProjectId { get; set; }

    public int? SubProjectId { get; set; }

    public int UserId { get; set; }

    public DateOnly Date { get; set; }

    public string? Notes { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Subproject? SubProject { get; set; }

    public virtual User User { get; set; } = null!;
}
