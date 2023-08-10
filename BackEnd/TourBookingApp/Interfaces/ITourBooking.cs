using TourBookingApp.Models;
using TourBookingApp.Models.DTO;

namespace TourBookingApp.Interfaces
{
    public interface ITourBooking
    {
        public Task<Booking> TourBooking(Booking booking);
        public Task<Booking> CancelTourBooking(int bookingId);
        public Task<BookingCountDTO> GetTourCount(int TourId);
    }
}
