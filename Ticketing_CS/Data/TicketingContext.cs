using Microsoft.EntityFrameworkCore;
using Ticketing_CS.Models;

namespace Ticketing_CS.Data
{
    public class TicketingContext :DbContext
    {
        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options) { }
        public DbSet<Ticketing> Ticketings { get; set; }
    }
}
