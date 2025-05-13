using Microsoft.AspNetCore.Mvc;

namespace Ticketing_CS.Controllers
{
    public class TicketingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
