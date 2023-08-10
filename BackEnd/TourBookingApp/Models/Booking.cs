using System.ComponentModel.DataAnnotations;

namespace TourBookingApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int TravellerId { get; set; }

        public  int TourId { get; set; }

        public  int PersonsCount { get; set; }
        public  DateTime BookingDate { get; set; }

        public ICollection<UserTourBooking> UserTourBookings { get; set; }
    }
}
