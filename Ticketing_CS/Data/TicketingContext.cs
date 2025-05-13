using Microsoft.EntityFrameworkCore;
using Ticketing_CS.Models;

namespace Ticketing_CS.Data
{
    public class TicketingContext :DbContext
    {
        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ticketing>()
				.HasOne(t => t.Level)
				.WithMany()
				.HasForeignKey(t => t.LevelId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Ticketing>()
				.HasOne(t => t.Urgency)
				.WithMany()
				.HasForeignKey(t => t.UrgencyId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Ticketing>()
				.HasOne(t => t.Status)
				.WithMany()
				.HasForeignKey(t => t.StatusId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Ticketing>()
				.HasOne(t => t.User)
				.WithMany()
				.HasForeignKey(t => t.UserId)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChoiceList>().HasData(
                    new ChoiceList { Id = 1, Choice= "On-Progress", Option="Status", IsActive = true},
					new ChoiceList { Id = 2, Choice = "Finished", Option = "Status", IsActive = true },
					new ChoiceList { Id = 3, Choice = "Cancelled", Option = "Status", IsActive = true },
					new ChoiceList { Id = 4, Choice = "On Waiting", Option = "Status", IsActive = true },
					new ChoiceList { Id = 5, Choice = "Normal", Option = "Urgency", IsActive = true },
					new ChoiceList { Id = 6, Choice = "Urgent", Option = "Urgency", IsActive = true },
					new ChoiceList { Id = 7, Choice = "Very Urgent", Option = "Urgency", IsActive = true },
					new ChoiceList { Id = 8, Choice = "Normal", Option = "Level", IsActive = true },
					new ChoiceList { Id = 9, Choice = "Medium", Option = "Level", IsActive = true },
					new ChoiceList { Id = 10, Choice = "Hard", Option = "Level", IsActive = true }
				);

			modelBuilder.Entity<User>().HasData(
					new User { Id = 1, UserName="Super", Password="1243", IsActive = true}
				);
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Ticketing> Ticketings { get; set; }
        public DbSet<ChoiceList> ChoiceList { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
