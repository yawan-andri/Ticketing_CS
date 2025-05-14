using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            LoadChoiceListItems("Level", "LevelChoiceList");
            LoadChoiceListItems("Urgency", "UrgencyChoiceList");
            LoadChoiceListItems("Status", "StatusChoiceList");

            var ticketings = await _context.Ticketings
                .Include(t => t.Level)
                .Include(t => t.Urgency)
                .Include(t => t.Status)
                .Include(t => t.User)
                .ToListAsync();
            return View(ticketings);
        }
        private void LoadChoiceListItems(string option, string viewBagKey) 
        {
            var choices = _context.ChoiceList
                .Where(c => c.Option == option && c.IsActive)
                .ToList();
            ViewData[viewBagKey] = new SelectList(choices, "Id", "Choice");
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadChoiceListItems("Level", "LevelChoiceList");
            LoadChoiceListItems("Urgency", "UrgencyChoiceList");
            LoadChoiceListItems("Status", "StatusChoiceList");
            return View();
        }
    }
}
