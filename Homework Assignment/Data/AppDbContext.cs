using Homework_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_Assignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

        public DbSet<Event> Events { get; set; }

       //Add seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, EventTitle = "Tech Workshop", Location = "Hall A", TicketPrice = 0 },
                new Event { Id = 2, EventTitle = "Music Festival", Location = "Main Stage", TicketPrice = 50 },
                new Event { Id = 3, EventTitle = "Career Fair", Location = "Block B", TicketPrice = 0 }
            );
        }
    }
}
