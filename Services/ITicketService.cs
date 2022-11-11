using TicketSystemBackend.Models;

namespace TicketSystemBackend.Services
{
    public interface ITicketService
    {
        ICollection<Ticket> GetAll();
        Ticket CreateTicket();
        Ticket UpdateTicket();
        bool CompleteTicket();
        Ticket SeeTicketDetails();
        Ticket BookmarkTicket();
    }
}
