using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Route("{id}")]
        [HttpPut]
        //public ActionResult Put(string name, string category, string detail, string completedByName, string completedByEmail, bool completed, string resolution)
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
