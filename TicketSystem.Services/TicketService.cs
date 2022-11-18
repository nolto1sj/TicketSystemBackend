using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Data.Models;
using TicketSystem.Data;

namespace TicketSystem.Services
{
    public interface ITicketService
    {
        ICollection<Ticket> GetAllTickets();
        ICollection<Ticket> GetTicketByString(string s);
        Ticket GetTicketById(int id);
        Ticket CreateTicket(string name, string category, string detail, string openedByName, string openedByEmail);
        bool DeleteTicketById(int id);
        void UpdateTicket(Ticket t);

        //METHODS FOR BOOKMARKS
        ICollection<Bookmark> GetAllBookmarks();
        public Bookmark AddToBookmarks(int id, string userId);
        public List<Ticket> GetBookmarkTicketsFromUser(string userId);

    }
    public class TicketService : ITicketService
    {
        private readonly TicketDbContext _context;

        public TicketService(TicketDbContext context)  /*HttpClient client*/ //add later?
        {
            _context = context;
        }

        //METHODS FOR TICKETS

        public ICollection<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket CreateTicket(string name, string category, string detail, string openedByName, string openedByEmail)
        {
            var ticket = new Ticket()
            {
                Name = name,
                Category = category,
                Detail = detail,
                OpenedByName = openedByName,
                OpenedByEmail = openedByEmail,
                Created = DateTime.Now,
                Completed = false
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public bool DeleteTicketById(int id)
        {
            var rowDeletion = _context.Tickets.Where(t => t.Id == id).ExecuteDelete();
            if (rowDeletion > 0) return true; else return false;
        }
       
        public Ticket? GetTicketById(int id)
        {
            return _context.Tickets.SingleOrDefault(t => t.Id == id);
        }

        public ICollection<Ticket> GetTicketByString(string s)
        {
            return _context.Tickets.Where(t => t.ToString().Contains(s)).ToList(); //test functionality
        }

        public void UpdateTicket(Ticket item)//passing in a modified ticket. cannot change id on ticket
        {
            var ticket = _context.Tickets.Find(item.Id);
            _context.Entry(ticket).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }

        //METHODS FOR BOOKMARKS

        public ICollection<Bookmark> GetAllBookmarks()
        {
            return _context.Bookmarks.ToList();
        }
        public Bookmark AddToBookmarks(int id, string userId)
        {
            var bookmark = new Bookmark() { TicketId = id, UserId = userId };
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();
            return bookmark;
        }
        public List<Ticket> GetBookmarkTicketsFromUser(string userId)
        {
            var ticket = from e in _context.Tickets
                         join b in _context.Bookmarks
                              on e.Id equals b.TicketId
                         where b.UserId == userId
                         select e;
            return ticket.ToList();
        }
    }
}
