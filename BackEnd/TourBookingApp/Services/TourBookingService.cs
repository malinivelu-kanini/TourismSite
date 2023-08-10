using TourBookingApp.Interfaces;
using TourBookingApp.Models;
using TourBookingApp.Models.DTO;

namespace TourBookingApp.Services
{
    public class TourBookingService : ITourBooking
    {
        private IRepo<int, Booking> _tourbookingRepo;
        public TourBookingService(IRepo<int, Booking> tourbookingRepo) 
        {
            _tourbookingRepo = tourbookingRepo;
        }
        public async Task<Booking> CancelTourBooking(int bookingId)
        {
            var bookings = await _tourbookingRepo.GetAll();
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                throw new Exception("Booking is Empty");
            }
            if(booking.BookingDate >= DateTime.UtcNow)
            {
                throw new Exception("After booking cannot able to cancel the booking");
            }

            var cancelbooking = await _tourbookingRepo.Delete(bookingId);
            if(cancelbooking != null)
            {
                return cancelbooking;
            }
            throw new Exception("Cant able to cancel booking right now");
            
        }

        public async Task<BookingCountDTO> GetTourCount(int TourId)
        {
            var bookings = await _tourbookingRepo.GetAll();

            var count = bookings.Where(booking => booking.TourId == TourId)
                .Sum(booking => booking.PersonsCount);

            return new BookingCountDTO { TourBookingCount = count };
        }

        public async Task<Booking> TourBooking(Booking booking)
        {
            var bookings = await _tourbookingRepo.GetAll();

            var existbooking = bookings.FirstOrDefault(b =>
            b.TravellerId == booking.TravellerId &&
            b.BookingDate.Date == booking.BookingDate.Date &&
            b.TourId == booking.TourId);

            if (existbooking != null)
            {
                throw new Exception("Booking Already Exists");
            }
            var newbooking = await _tourbookingRepo.Add(booking);
            if (newbooking != null)
            {
                return newbooking;
            }
            throw new Exception("Fail to add booking right now");
        }
    }
}
