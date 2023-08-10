using Microsoft.EntityFrameworkCore;

namespace TourBookingApp.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options): base(options) 
        {

        }
        public DbSet<Booking> Bookings { get; set; } 
        public DbSet<UserTourBooking> UserTourBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Booking>()
                .HasMany(b => b.UserTourBookings)
                .WithOne(bu => bu.Booking)
                .HasForeignKey(bu => bu.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
