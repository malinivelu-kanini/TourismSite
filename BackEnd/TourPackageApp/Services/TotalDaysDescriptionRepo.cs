﻿using TourPackageApp.Interfaces;
using TourPackageApp.Models;

namespace TourPackageApp.Services
{
    public class TotalDaysDescriptionRepo : IRepo<int, TotalDaysDescription>
    {
        private readonly Context _context;

        public TotalDaysDescriptionRepo(Context context)
        {
            _context = context;

        }
        public async Task<TotalDaysDescription?> Add(TotalDaysDescription item)
        {
            if (item != null)
            {
                _context.TotalDaysDescriptions.Add(item);
                _context.SaveChanges();
                return item;

            }
            return null;
        }

        public Task<TotalDaysDescription?> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<TotalDaysDescription?> Get(int key)
        {
            var totalDaysDescription = _context.TotalDaysDescriptions.FirstOrDefault(p => p.TotalDaysDescriptionId == key);
            if (totalDaysDescription != null)
            {
                return totalDaysDescription;
            }
            return null;
        }

        public async Task<ICollection<TotalDaysDescription>?> GetAll()
        {
            var totalDaysDescriptions = _context.TotalDaysDescriptions.ToList();
            if (totalDaysDescriptions.Count > 0)
            {
                return totalDaysDescriptions;
            }
            return null;
        }

        public Task<TotalDaysDescription?> Update(TotalDaysDescription item)
        {
            throw new NotImplementedException();
        }
    }
}
