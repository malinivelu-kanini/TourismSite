using Microsoft.EntityFrameworkCore;

namespace TourPackageImagesApp.Models
{
    public class TourImageContext: DbContext
    {
        public TourImageContext(DbContextOptions<TourImageContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Tour> Tourr { get; set; }
        public DbSet<TourImages> TourImagess { get; set; }
    }
}
