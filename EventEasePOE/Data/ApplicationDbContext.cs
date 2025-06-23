using Microsoft.EntityFrameworkCore;
using EventEasePOE.Models;

namespace EventEasePOE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Booking> Bookings { get; set; } // Added Booking entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: Event belongs to a Venue
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId);

            // Relationship: Booking belongs to an Event
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany() // You can also have .WithMany(e => e.Bookings) in Event.cs if needed
                .HasForeignKey(b => b.EventId);
        }
    }
}

