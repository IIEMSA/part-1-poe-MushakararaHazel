using Microsoft.EntityFrameworkCore;
using EventEase.Models; // Your models namespace

namespace EventEase.Data
{
   
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
            public DbSet<Venue> Venues { get; set; } = null!;
            public DbSet<Events> Events { get; set; } = null!;
            public DbSet<Booking> Bookings { get; set; } = null!;

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Prevent duplicate venue-event bookings
                modelBuilder.Entity<Booking>()
                    .HasIndex(b => new { b.EventId, b.VenueId })
                    .IsUnique();

                // Configure cascade behavior
                modelBuilder.Entity<Venue>()
                    .HasMany(v => v.Bookings)
                    .WithOne(b => b.Venue)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent venue deletion if bookings exist

                modelBuilder.Entity<Events>()
                    .HasMany(e => e.Bookings)
                    .WithOne(b => b.Event)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venue>().HasData(
    new Venue { VenueId = 1, VenueName = "Grand Ballroom", Location = "123 Main St", Capacity = 500 },
    new Venue { VenueId = 2, VenueName = "Conference Center", Location = "456 Oak Ave", Capacity = 200 }
    );
            }
        }
    } 