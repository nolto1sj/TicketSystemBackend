using System;
using System.Collections.Generic;

namespace TicketSystemBackend.Models;

public partial class Bookmark
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? TicketId { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
