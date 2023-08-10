using TourFeedBackApp.Interfaces;
using TourFeedBackApp.Models;

namespace TourFeedBackApp.Services
{
    public class FeedBackService : IFeedBack
    {
        private IRepo<int, FeedBack> _feedbackRepo;
        public FeedBackService(IRepo<int, FeedBack>feedbackRepo)
        {
            _feedbackRepo=feedbackRepo;
            
        }
        public async Task<FeedBack> AddFeedback(FeedBack feedback)
        {
            var newFeedback= await _feedbackRepo.Add(feedback);
            if(newFeedback != null)
            {
                return newFeedback;
            }
            throw new Exception("Cannot able to add feedback");
            
        }

        public async Task<ICollection<FeedBack>> GetTopRatingsFeedBack()
        {
            var feedbackCollection = await _feedbackRepo.GetAll();
            var topratingFeedback = feedbackCollection.Where(f => f.Ratings > 4);
            if (topratingFeedback != null)
            {
                return topratingFeedback.ToList();
            }
            throw new Exception("cant get feedback right now");
        }
    }
}




