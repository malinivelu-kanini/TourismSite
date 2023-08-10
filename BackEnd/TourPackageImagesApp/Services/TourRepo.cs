using Microsoft.EntityFrameworkCore;
using TourPackageImagesApp.Interfaces;
using TourPackageImagesApp.Models;

namespace TourPackageImagesApp.Services
{
    public class TourRepo : IRepo<int, Tour>
    {
        private readonly TourImageContext _context;

        public TourRepo(TourImageContext context)
        {
            _context = context;
        }
        public async Task<Tour?> Add(Tour item)
        {
            if (item != null)
            {
                _context.Tourr.Add(item);
                await _context.SaveChangesAsync();
                return item;

            }
            return null;
        }

        public async Task<Tour?> Get(int key)
        {
            var tour = await _context.Tourr.FindAsync(key);
            if (tour != null)
            {
                return tour;
            }
            return null;
        }

        public async Task<ICollection<Tour?>> GetAll()
        {
           return await _context.Tourr.ToListAsync();
        }

    }
}
