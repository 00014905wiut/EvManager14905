using Microsoft.EntityFrameworkCore;
using evmanager14905v2.Models;

namespace evmanager14905v2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventRating> EventRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasOne(e => e.EventRating)
                .WithOne(er => er.Event)
                .HasForeignKey<EventRating>(er => er.EventId);
        }
    }
}

