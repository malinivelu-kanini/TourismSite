using Microsoft.EntityFrameworkCore;

namespace TourFeedBackApp.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<FeedBack>? FeedBacks { get; set; }
    }
}
