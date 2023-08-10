using LoginandSignup.Models;
using LoginandSignup.Interfaces;
using LoginandSignup.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginandSignup.Services
{
    public class TravellerRepo : IRepo<Traveller,int>
    {
        private readonly UserContext _context;
        private readonly ILogger<User> _logger;

        public TravellerRepo(UserContext context, ILogger<User> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Traveller?> Add(Traveller item)
        {
            try
            {
                _context.Traveller.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Traveller?> Delete(int key)
        {
            try
            {
                var traveller = await Get(key);
                if (traveller != null)
                {
                    _context.Traveller.Remove(traveller);
                    await _context.SaveChangesAsync();
                    return traveller;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Traveller?> Get(int key)
        {
            try
            {
                var traveller = await _context.Traveller.Include(i => i.Users).FirstOrDefaultAsync(i => i.TravellerId == key);
                return traveller;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Traveller>?> GetAll()
        {
            try
            {
                var traveller = await _context.Traveller.ToListAsync();
                if (traveller.Count > 0)
                    return traveller;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Traveller?> Update(Traveller item)
        {
            try
            {
                var traveller = _context.Traveller.FirstOrDefault(u => u.TravellerId == item.TravellerId); ;
                if (traveller != null)
                {
                  
                    traveller.PhoneNumber = item.PhoneNumber != null ? item.PhoneNumber : traveller.PhoneNumber;

                    await _context.SaveChangesAsync();
                    return traveller;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
