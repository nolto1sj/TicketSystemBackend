using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly ITicketService _service;

        public BookmarkController(ITicketService service)
        {
            _service = service;
        }

        [Route("allbookmarks")]
        [HttpGet]
        public ActionResult Get()
        {
            var tickets = _service.GetAllBookmarks();
            return Ok(tickets);
        }

        [Route("addtobookmark/{id}/{userid}")]
        [HttpGet]
        public ActionResult Bookmark(int id, string userId)
        {
            var bookmark = _service.AddToBookmarks(id, userId);
            return Ok(bookmark);
        }

        [Route("viewbookmarks/{userid}")]
        [HttpGet]
        public ActionResult GetBookmarkFromUser(string userId)
        {
            var bookmark = _service.GetBookmarkTicketsFromUser(userId);
            return Ok(bookmark);
        }
    }
}
