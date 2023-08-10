using TourFeedBackApp.Interfaces;
using TourFeedBackApp.Models;

namespace TourFeedBackApp.Services
{
    public class FeedBackRepo : IRepo<int, FeedBack>
    {
        private Context _context;
        public FeedBackRepo(Context context)
        {
            _context = context;
            
        }
        public async  Task<FeedBack> Add(FeedBack item)
        {
            if (item!=null) 
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;

            }
            return null;
        }

        public async Task<FeedBack> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<FeedBack>> GetAll()
        {
           return _context.FeedBacks.ToList();
        }
    }
}
