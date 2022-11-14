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
        Ticket UpdateTicket(Ticket t);
    }
    public class TicketService : ITicketService
    {
        private readonly TicketDbContext _context;
        //private readonly HttpClient _client;

        public TicketService(TicketDbContext context)  /*HttpClient client*/ //add later?
        {
            _context = context;
            //_client = client;
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

        public ICollection<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? GetTicketById(int id)
        {
            return _context.Tickets.SingleOrDefault(t => t.Id == id);
        }

        public ICollection<Ticket> GetTicketByString(string s)
        {
            return _context.Tickets.Where(t => t.ToString().Contains(s)).ToList(); //test functionality
        }

        public Ticket UpdateTicket(Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
