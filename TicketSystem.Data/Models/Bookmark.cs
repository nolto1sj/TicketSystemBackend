using System;
using System.Collections.Generic;

namespace TicketSystem.Data.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? TicketId { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
