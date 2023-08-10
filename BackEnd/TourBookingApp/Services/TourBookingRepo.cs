using Microsoft.EntityFrameworkCore;
using TourBookingApp.Interfaces;
using TourBookingApp.Models;

namespace TourBookingApp.Services
{
    public class TourBookingRepo : IRepo<int, Booking>
    {
        private Context _context;
        public TourBookingRepo(Context context)
        {
            _context=context;
            
        }
        public async Task<Booking> Add(Booking item)
        {
           _context.Bookings.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<Booking> Delete(int key)
        {
            var deletebooking = await _context.Bookings.FindAsync(key);

            if (deletebooking != null)
            {
                return null;
            }
            _context.Bookings.Remove(deletebooking);
            await _context.SaveChangesAsync();
            return deletebooking;
        }

        public async Task<Booking> Get(int key)
        {
            var booking = await _context.Bookings.FindAsync(key);
            if (booking != null)
            
                return booking;
            return booking;
        }

        public async Task<ICollection<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }
    }
}
