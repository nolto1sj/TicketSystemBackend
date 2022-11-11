using System;
using System.Collections.Generic;

namespace TicketSystemBackend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public DateTime Created { get; set; }

    public string? OpenedByName { get; set; }

    public string? OpenedByEmail { get; set; }

    public string? CompletedByName { get; set; }

    public string? CompletedByEmail { get; set; }

    public bool Completed { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; } = new List<Bookmark>();
}
