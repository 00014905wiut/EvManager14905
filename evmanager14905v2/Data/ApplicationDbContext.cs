using evmanager14905v2.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Event>().HasKey(pc => pc.EventId);
            modelBuilder.Entity<EventRating>().HasKey(pc => pc.RatingId);
            modelBuilder.Entity<EventRating>().HasOne(p => p.Event);
        }
    }

    
}
