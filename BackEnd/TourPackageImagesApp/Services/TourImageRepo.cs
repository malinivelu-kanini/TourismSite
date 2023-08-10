using Microsoft.EntityFrameworkCore;
using TourPackageImagesApp.Interfaces;
using TourPackageImagesApp.Models;

namespace TourPackageImagesApp.Services
{
    public class TourImageRepo : IRepo<int, TourImages>
    {
        private readonly TourImageContext _context;

        public TourImageRepo(TourImageContext context)
        {
            _context = context;
        }
        public async Task<TourImages?> Add(TourImages item)
        {
            if (item != null)
            {
                _context.TourImagess.Add(item);
                await _context.SaveChangesAsync();
                return item;

            }
            return null;
        }

        public async Task<TourImages?> Get(int key)
        {

            var tour = await _context.TourImagess.FindAsync(key);
            if (tour != null)
            {
                return tour;
            }
            return null;
        }

        public async Task<ICollection<TourImages?>> GetAll()
        {
            return await _context.TourImagess.ToListAsync();
        }
    }
}
