using TourFeedBackApp.Models;

namespace TourFeedBackApp.Interfaces
{
    public interface IFeedBack
    {
        public Task<ICollection<FeedBack>> GetTopRatingsFeedBack();
        public Task<FeedBack> AddFeedback(FeedBack feedback);
    }
}
