using Microsoft.AspNetCore.Mvc;
using TicketsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private static readonly List<Ticket> Tickets = new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                ShortDescription = "Metro",
                Description = "This is a Metro ticket description.",
                CreatedDate = DateTime.UtcNow.AddDays(-2),
                Severity = "High",
                TargetDate = DateTime.UtcNow.AddDays(5),
                Status = "Open"
            },
            new Ticket
            {
                Id = 2,
                ShortDescription = "Movie",
                Description = "This is another Movie ticket description.",
                CreatedDate = DateTime.UtcNow.AddDays(-1),
                Severity = "Medium",
                TargetDate = DateTime.UtcNow.AddDays(10),
                Status = "In Progress"
            },
            new Ticket
            {
                Id = 3,
                ShortDescription = "Performance regression",
                Description = "API response times spiked after release",
                CreatedDate = new DateTime(2025, 6, 1),
                Severity = "Critical",
                TargetDate = new DateTime(2025, 6, 12),
                Status = "Investigating"
            }
        };

        [HttpGet]
        public ActionResult<List<Ticket>> GetTickets()
        {
            return Ok(Tickets);
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicketById(int id)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }
    }
}