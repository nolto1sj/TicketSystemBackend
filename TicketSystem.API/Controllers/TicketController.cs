using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [Route("alltickets")]
        [HttpGet]
        public ActionResult Get()
        {
            var tickets = _service.GetAllTickets();
            return Ok(tickets);
        }

        [Route("createticket")]
        [HttpPost]
        public ActionResult Post(Ticket ticket)
        {
            var newTicket = _service.CreateTicket(ticket.Name, ticket.Category, ticket.Detail, ticket.OpenedByName, ticket.OpenedByEmail);
            return Ok(newTicket);
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Put(Ticket t)
        {
            _service.UpdateTicket(t);
            return Ok();

        }

        //[HttpDelete]
        //public ActionResult Delete()
        //{
        //    _service.DeleteTicketById();
        //}
    }
}
