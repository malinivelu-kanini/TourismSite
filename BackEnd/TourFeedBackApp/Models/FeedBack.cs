using System.ComponentModel.DataAnnotations;

namespace TourFeedBackApp.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackId { get; set; }
        public string? FeedBackDescription { get; set; }
        public string? UserEmail { get; set; }
        public string? TourImage { get; set; }
        public int? Ratings { get; set; }

    }
}
