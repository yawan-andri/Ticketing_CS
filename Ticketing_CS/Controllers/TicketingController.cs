using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketing_CS.Data;

namespace Ticketing_CS.Controllers
{
    public class TicketingController : Controller
    {
        private readonly TicketingContext _context;
        public TicketingController(TicketingContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ticketings = await _context.Ticketings
                .Include(t => t.Level)
                .Include(t => t.Urgency)
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToListAsync();
            return View(ticketings);
        }
    }
}
